
using UnityEditor;
using UnityEngine;

// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
[CustomEditor(typeof(MyTreeAsset1))]
[CanEditMultipleObjects]
public class MyTreeAsset1Editor : Editor
{   
    
    SerializedProperty field_elements;

    private void OnEnable() {
        field_elements = serializedObject.FindProperty("elements");
    }

    public override void OnInspectorGUI()
    {
        //The variables and GameObject from the MyGameObject script are displayed in the Inspector with appropriate labels
        // EditorGUILayout.PropertyField(field_elements, new GUIContent("Elements"), GUILayout.Height(20));
        EditorGUILayout.PropertyField(field_elements, new GUIContent("Elements"));

        // Apply changes to the serializedProperty - always do this at the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}