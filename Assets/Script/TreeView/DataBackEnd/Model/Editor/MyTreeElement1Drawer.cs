using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

// ItemDrawerUIE
[CustomPropertyDrawer(typeof(MyTreeElement1))]
public class MyTreeElement1Drawer : PropertyDrawer
{
    // public override VisualElement CreatePropertyGUI(SerializedProperty property)
    // {
    //     Debug.Log("CreatePropertyGUI");
    //     // Create property container element.
    //     var container = new VisualElement();

    //     // Create property fields.
    //     var popup = new UnityEngine.UIElements.PopupWindow(); 
    //     popup.text = "Item";
    //     var type = new PropertyField(property.FindPropertyRelative("m_Type"));
    //     // var unitField = new PropertyField(property.FindPropertyRelative("unit"));
    //     // var nameField = new PropertyField(property.FindPropertyRelative("name"), "Fancy Name");

    //     // Add fields to the container.
    //     popup.Add(type);
    //     // popup.Add(unitField);
    //     // popup.Add(nameField);
        
    //     container.Add(popup);

    //     return container;
    // }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Display the property's value
        EditorGUI.PropertyField(position, property, label, true);

        EditorGUI.EndProperty();
    }
}