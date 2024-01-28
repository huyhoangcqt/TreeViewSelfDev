
using UnityEditor;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEngine.UIElements;
using System.Collections.Generic;

// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
[CustomEditor(typeof(MyTreeAsset1))]
// [CanEditMultipleObjects]
public class MyTreeAsset1Editor : Editor
{   
    TreeViewState m_TreeViewState;
    MyTreeView1 m_MyTreeView1;
    TreeModel<MyTreeElement1> m_TryModel;
    MyTreeAsset1 m_MyTreeAsset;
    private bool isNeedReloadData = true;
    private string lastSelectedTreeAssetName = string.Empty;
    SerializedProperty field_elements;
    public Rect treeViewRect
    {
        get { return new Rect(20, 30, 360-40, 720-60); }
    }

    // private void OnEnable() {
    //     field_elements = serializedObject.FindProperty("elements");
    // }

    // public override void OnInspectorGUI()
    // {
    //     InitIfNeed();
    //     //The variables and GameObject from the MyGameObject script are displayed in the Inspector with appropriate labels
    //     // EditorGUILayout.PropertyField(field_elements, new GUIContent("Elements"), GUILayout.Height(20));
    //     EditorGUILayout.PropertyField(field_elements, new GUIContent("Elements"));

    //     // Apply changes to the serializedProperty - always do this at the end of OnInspectorGUI.
    //     serializedObject.ApplyModifiedProperties();
    // }        

    // // private 

    // private  void InitIfNeed()
    // {
    //     if (isNeedReloadData)
    //     {
    //         isNeedReloadData = false;
    //         Debug.Log("InitTreeView");
    //         m_TryModel = new TreeModel<MyTreeElement1>(m_MyTreeAsset.elements);
    //         m_MyTreeView1 = new MyTreeView1(m_TreeViewState, m_TryModel);
    //     }
    // }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("elements"), true);

        serializedObject.ApplyModifiedProperties();
    }

    // public override VisualElement CreateInspectorGUI()
    // {
    //     VisualElement defaultInspector = base.CreateInspectorGUI();
    //     // SerializedProperty elements = serializedObject.FindProperty("elements");
    //     // if (elements != null && (elements.objectReferenceValue as List<MyTreeElement1>) != null){

    //     // }
    //     return defaultInspector;
    // }

    // private void DoTreeView()
    // {
    //     m_MyTreeView1.OnGUI(treeViewRect);
    // }
}