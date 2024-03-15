

using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;

// [CustomPropertyDrawer(typeof(MyTreeElementOrigin))]
// public class MyTreeElementOriginDrawer: PropertyDrawer {

//     public override VisualElement CreatePropertyGUI(SerializedProperty property)
//     {
//         // Debug.Log("CreatePropertyGUI");
//         // Create property container element.
//         var container = new VisualElement();

//         // Create property fields.
//         var popup = new UnityEngine.UIElements.PopupWindow(); 
//         popup.text = "Item";
//         var displayName = new PropertyField(property.FindPropertyRelative("m_DisplayName"));

//         // Add fields to the container.
//         popup.Add(displayName);

//         container.Add(popup);

//         return container;
//     }
// }

[CustomPropertyDrawer(typeof(MyTreeElementOrigin))]
public class MyTreeElementOriginDrawer: Editor 
{ 
    SerializedProperty id;
    SerializedProperty depth;
    SerializedProperty name;


    private void OnEnable() {
        // id = serializedObject.FindProperty("m_Id");
        // depth = serializedObject.FindProperty("m_Depth");
        name = serializedObject.FindProperty("m_DisplayName");
    }

    private void OnGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(name, true);
        serializedObject.ApplyModifiedProperties();
    }

    private void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(name, true);
        serializedObject.ApplyModifiedProperties();
    }
}