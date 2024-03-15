using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MyCollection.Element))]
public class MyCollectionElementDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EditorGUI.PropertyField(position, property, true);

        EditorGUI.EndProperty();
    }
}