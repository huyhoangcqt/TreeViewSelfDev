

using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(MyTreeElement2))]
public class MyTreeElement2Drawer: PropertyDrawer {
    // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        
    // }
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var displayName = new PropertyField(property.FindPropertyRelative("m_DisplayName"));
        
        // var type = new PropertyField(property.FindProperty("m_Type"));
        // COMMENT: line above is wrong.
        var type = new PropertyField(property.FindPropertyRelative("m_Type"));

        var rare = new PropertyField(property.FindPropertyRelative("m_Rare"));
        var size = new PropertyField(property.FindPropertyRelative("m_DataSize"));

        container.Add(displayName);
        container.Add(type);
        container.Add(rare);
        container.Add(size);

        return container;
    }
}