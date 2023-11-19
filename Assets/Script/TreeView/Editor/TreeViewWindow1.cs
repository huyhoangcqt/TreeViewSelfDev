using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEditor;

public class TreeViewWindow1 : EditorWindow {
    [SerializeField] TreeViewState m_TreeViewState;

    //The TreeView is not serializable, so it should be reconstructed from the tree data.
    SimpleTreeView m_SimpleTreeView;

    void OnEnable ()
    {
        // Check whether there is already a serialized view state (state 
        // that survived assembly reloading)
        if (m_TreeViewState == null)
            m_TreeViewState = new TreeViewState ();

        m_SimpleTreeView = new SimpleTreeView(m_TreeViewState);
    }

    void OnGUI ()
    {
        m_SimpleTreeView.OnGUI(new Rect(0, 0, position.width, position.height));
    }

    // Add menu named "My Window" to the Window menu
    [MenuItem ("TreeView Examples/TreeViewSample1")]
    static void ShowWindow ()
    {
        // Get existing open window or if none, make a new one:
        var window = GetWindow<TreeViewWindow1> ();
        window.titleContent = new GUIContent ("My Window");
        window.Show ();
    }
}
