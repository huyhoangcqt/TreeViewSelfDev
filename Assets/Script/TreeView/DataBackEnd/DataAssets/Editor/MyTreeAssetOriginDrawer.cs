
using UnityEditor;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(MyTreeAssetOrigin))]
public class MyTreeAssetOriginDrawer : Editor
{   
    TreeViewState m_TreeViewState;
    MyTreeViewOrigin m_MyTreeViewOrigin;
    TreeModel<MyTreeElementOrigin> m_TryModel;
    MyTreeAssetOrigin m_MyTreeAsset;
    private bool isNeedReloadData = true;
    private string lastSelectedTreeAssetName = string.Empty;

    private void OnGUI() {
        Debug.Log("OnGUI");
    }

    private void OnEnable() {
        Debug.Log("OnEnable");        
    }

    public override void OnInspectorGUI()
    {            
        Debug.Log("OnInspectorGUI");
        InitIfNeed(serializedObject);

        GUILayout.BeginVertical();
        DrawToolBar();
        DoTreeView();
        GUILayout.EndVertical();
    }

    // Editor => CreateInspectorGUI();
    public override VisualElement CreateInspectorGUI()
    {
        Debug.Log("CreateInspectorGUI");
        InitIfNeed(serializedObject);
        var root = ManualCreateRootElement(serializedObject);
        return root;
    }

    public VisualElement ManualCreateRootElement(SerializedObject property)
    {
        VisualElement defaultInspector = new VisualElement();

        VisualElement headbar = new VisualElement();
        defaultInspector.Add(headbar);
        
        Label headbarLabel = new Label("Headbar");
        headbar.Add(headbarLabel);
        
        Button generateBtn = new Button(() => {

        });
        generateBtn.text = "Create Instantiate";

        VisualElement container = new VisualElement();
        defaultInspector.Add(container);

        SerializedProperty _listProperty = property.FindProperty("elements");
        PropertyField listView = new PropertyField(_listProperty);
        listView.name = "elements";
        listView.label = "elements 2";
        container.Add(listView);

        return defaultInspector;
    }

    public VisualElement LoadVisualElementFromUXML()
    {
        //Load from UXML
        //SAMPLE:
        // var visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Script/ListViewExample/Example3_ListSO/Editor/uxml/CarStore.uxml");
        // VisualElement root = visualTreeAsset.Instantiate();
        //...
        return new VisualElement();
    }

    #region InitData

        private void InitIfNeed(SerializedObject so)
        {
            if (isNeedReloadData)
            {
                isNeedReloadData = false;
                Debug.Log("InitTreeView");
                
                InitMyTreeAsset(so);

                m_TryModel = new TreeModel<MyTreeElementOrigin>(m_MyTreeAsset.elements);
                m_MyTreeViewOrigin = new MyTreeViewOrigin(m_TreeViewState, m_TryModel);
            }
        }

        private void InitMyTreeAsset(SerializedObject so)
        {
            var elements = so.FindProperty("elements");

            m_MyTreeAsset = new MyTreeAssetOrigin();
            m_MyTreeAsset.elements = new List<MyTreeElementOrigin>();

            // SerializedProperty element = null;
            // for (int i = 0; i < elements.arraySize; i++){
            //     element = elements.GetArrayElementAtIndex(i);
            // }

            var enumerator = elements.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var elementField = enumerator.Current as SerializedProperty;
                var id = elementField.FindPropertyRelative("m_Id").intValue;
                var depth = elementField.FindPropertyRelative("m_Depth").intValue;
                var name = elementField.FindPropertyRelative("m_DisplayName").stringValue;
                MyTreeElementOrigin elementItem = new MyTreeElementOrigin(id, depth, name);
                m_MyTreeAsset.elements.Add(elementItem);
            }
        }

    #endregion IntiData!

    #region Drawing Method:

        private void DrawToolBar()
        {
            EditorGUILayout.BeginHorizontal();
            m_MyTreeAsset = EditorGUILayout.ObjectField(m_MyTreeAsset, typeof(MyTreeAssetOrigin), true) as MyTreeAssetOrigin;
            if (lastSelectedTreeAssetName == null || lastSelectedTreeAssetName != m_MyTreeAsset.name)
            {
                OnSelectTreeAsset();
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DoTreeView()
        {
            m_MyTreeViewOrigin.OnGUI(treeviewRect);
        }

        Rect toolbarRect;
        Rect treeviewRect;
        private void InitRect()
        {
            float width = EditorGUIUtility.currentViewWidth;
            float height = Screen.height * (width / Screen.width) - 160;

            toolbarRect = new Rect(0, 0, width, 40);
            treeviewRect = new Rect(0, 40, width, height - 40);
        }

    #endregion Drawing Method!

    #region Binging Methods
        public void OnCreateInstantiateClick()
        {
            
        }

        private void OnSelectTreeAsset()
        {
            lastSelectedTreeAssetName = m_MyTreeAsset.name;
            isNeedReloadData = true;
        }
    #endregion Binging Methods!
}

// [CustomPropertyDrawer(typeof(MyTreeAssetOrigin))]
// public class MyTreeAssetOriginDrawer : PropertyDrawer
// {   
//     TreeViewState m_TreeViewState;
//     MyTreeViewOrigin m_MyTreeViewOrigin;
//     TreeModel<MyTreeElementOrigin> m_TryModel;
//     MyTreeAssetOrigin m_MyTreeAsset;
//     private bool isNeedReloadData = true;
//     private string lastSelectedTreeAssetName = string.Empty;
//     SerializedProperty field_elements;
//     // Drawer => CreatePropertyGUI(SerializedProperty property)
//     public override VisualElement CreatePropertyGUI(SerializedProperty property)
//     {
//         InitIfNeed();
        
//         VisualElement defaultInspector = ManualCreateRootElement(property);
        
//         return defaultInspector;
//     }

//     public VisualElement ManualCreateRootElement(SerializedProperty property)
//     {
//         VisualElement defaultInspector = new VisualElement();

//         VisualElement container = new VisualElement();
//         defaultInspector.Add(container);

//         SerializedProperty _listProperty = property.FindPropertyRelative("elements");
//         PropertyField listView = new PropertyField(_listProperty);
//         listView.name = "elements";
//         listView.label = "elements 2";
//             container.Add(listView);

//         return defaultInspector;
//     }

//     private void InitIfNeed()
//     {
//         if (isNeedReloadData)
//         {
//             isNeedReloadData = false;
//             Debug.Log("InitTreeView");
//             m_TryModel = new TreeModel<MyTreeElementOrigin>(m_MyTreeAsset.elements);
//             m_MyTreeViewOrigin = new MyTreeViewOrigin(m_TreeViewState, m_TryModel);
//         }
//     }

//     private void DoTreeView()
//     {
//         m_MyTreeViewOrigin.OnGUI(treeViewRect);
//     }
// }