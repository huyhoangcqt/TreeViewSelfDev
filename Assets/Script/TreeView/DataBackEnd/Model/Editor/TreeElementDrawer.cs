using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

// ItemDrawerUIE
// [CustomPropertyDrawer(typeof(TreeElement))]
// public class TreeElementDrawer : PropertyDrawer
// {
//     public override VisualElement CreatePropertyGUI(SerializedProperty property)
//     {
//         Debug.Log("CreatePropertyGUI");
//         // Create property container element.
//         var container = new VisualElement();

//         // Create property fields.
//         var popup = new UnityEngine.UIElements.PopupWindow(); 
//         popup.text = "Item";
//         var amountField = new PropertyField(property.FindPropertyRelative("m_DisplayName"));
//         // var unitField = new PropertyField(property.FindPropertyRelative("unit"));
//         // var nameField = new PropertyField(property.FindPropertyRelative("name"), "Fancy Name");

//         // Add fields to the container.
//         popup.Add(amountField);
//         // popup.Add(unitField);
//         // popup.Add(nameField);
        
//         container.Add(popup);

//         return container;
//     }

//     // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     // {
//     //     EditorGUI.BeginProperty(position, label, property);

//     //     // Display the property's value
//     //     EditorGUI.PropertyField(position, property, label, true);

//     //     EditorGUI.EndProperty();
//     // }
// }

[CustomPropertyDrawer(typeof(TreeElement))]
public class TreeElementDrawer: Editor 
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