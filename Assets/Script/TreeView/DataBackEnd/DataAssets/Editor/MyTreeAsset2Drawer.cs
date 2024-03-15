
// using UnityEditor;
// using UnityEngine;
// using UnityEditor.IMGUI.Controls;
// using UnityEngine.UIElements;
// using System.Collections.Generic;
// using UnityEditor.UIElements;

// // // Custom Editor using SerializedProperties.
// // // Automatic handling of multi-object editing, undo, and Prefab overrides.
// [CustomPropertyDrawer(typeof(MyTreeAsset2))]
// public class MyTreeAsset2Drawer : PropertyDrawer
// {   
//     // TreeViewState m_TreeViewState;
//     // MyTreeView1 m_MyTreeView1;
//     // TreeModel<MyTreeElement1> m_TryModel;
//     // MyTreeAsset2 m_MyTreeAsset;
//     // private bool isNeedReloadData = true;
//     // private string lastSelectedTreeAssetName = string.Empty;
//     // SerializedProperty field_elements;

//     //Editor => CreateInspectorGUI();
//     // public override VisualElement CreateInspectorGUI()
//     // {
//     //     // var root = GetOldCustomElelemnts();
//     //     var visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Script/ListViewExample/Example3_ListSO/Editor/uxml/CarStore.uxml");
//     //     VisualElement root = visualTreeAsset.Instantiate();
//     //     return root;
//     // }

//     // Drawer => CreatePropertyGUI(SerializedProperty property)
//     public override VisualElement CreatePropertyGUI(SerializedProperty property)
//     {
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
//         container.Add(listView);

//         return defaultInspector;
//     }

//     public VisualElement LoadVisualElementFromUXML()
//     {
//         return new VisualElement();
//     }
// }