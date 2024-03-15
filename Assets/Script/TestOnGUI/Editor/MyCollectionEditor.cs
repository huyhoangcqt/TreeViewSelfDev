using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyCollection))]
public class MyCollectionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("elements"), true);

        serializedObject.ApplyModifiedProperties();
    }
}
