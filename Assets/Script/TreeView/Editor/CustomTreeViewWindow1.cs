using System;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEditor;

public class CustomTreeViewWindow1 : EditorWindow 
{
    #region Attributes

        [SerializeField] TreeViewState m_TreeViewState;
        [SerializeField] MyTreeView1 m_MyTreeView1;
        TreeModel<MyTreeElement1> m_TryModel;
        [SerializeField] MyTreeAsset1 m_MyTreeAsset;
        private bool isNeedReloadData = true;
        private string lastSelectedTreeAssetName = string.Empty;

    #endregion Attributes!

    public Rect treeViewRect
    {
        get { return new Rect(20, 30, position.width-40, position.height-60); }
    }

    public Rect toolbarRect
    {
        get { return new Rect (20f, 10f, position.width-40f, 20f); }
    }

    // Add menu named "My Window" to the Window menu
    [MenuItem ("TreeView Examples/CustomTreeViewWindow1")]
    public static CustomTreeViewWindow1 GetWindow()
    {
        // Get existing open window or if none, make a new one:
        var window = GetWindow<CustomTreeViewWindow1> ();
        window.titleContent = new GUIContent ("CustomTreeViewWindow1");
        window.Focus();
        window.Repaint();
        return window;
    }

    void OnEnable ()
    {
        if (m_TreeViewState == null)
            m_TreeViewState = new TreeViewState ();

        m_MyTreeAsset = GetData();
    }

    private MyTreeAsset1 GetData()
    {
        Debug.Log("GetData");
        if (m_MyTreeAsset != null){
            return m_MyTreeAsset;
        }

        List<MyTreeElement1> elements = TreeAssetAutoGenerate.Generate<MyTreeElement1>(maxItem: 100, maxDepth: 3);
        m_MyTreeAsset = new MyTreeAsset1();
        m_MyTreeAsset.elements = elements;
        return m_MyTreeAsset;
    }

    private void SetTreeAsset(MyTreeAsset1 asset)
    {
        Debug.Log("SetTreeAsset");
        m_MyTreeAsset = asset;
    }

    #region OnGUI

        void OnGUI ()
        {
            Debug.Log("OnGUI");
            InitIfNeed();

            GUILayout.BeginVertical();
            DrawToolBar();
            DoTreeView();
            GUILayout.EndVertical();
        }

        private void DrawToolBar()
        {
            EditorGUILayout.BeginHorizontal();
            m_MyTreeAsset = EditorGUILayout.ObjectField(m_MyTreeAsset, typeof(MyTreeAsset1), true) as MyTreeAsset1;
            if (lastSelectedTreeAssetName == null || lastSelectedTreeAssetName != m_MyTreeAsset.name)
            {
                OnSelectTreeAsset();
            }
            EditorGUILayout.EndHorizontal();

            // if (GUILayout.Button("Search!"))
            // {
            //     if (m_MyTreeAsset == null)
            //         ShowNotification(new GUIContent("No object selected for searching"));
            //     else if (Help.HasHelpForObject(m_MyTreeAsset))
            //         Help.ShowHelpForObject(m_MyTreeAsset);
            //     else
            //         Help.BrowseURL("https://forum.unity3d.com/search.php");
            // }
        }

        private  void InitIfNeed()
        {
            if (isNeedReloadData)
            {
                isNeedReloadData = false;
                Debug.Log("InitTreeView");
                m_TryModel = new TreeModel<MyTreeElement1>(m_MyTreeAsset.elements);
                m_MyTreeView1 = new MyTreeView1(m_TreeViewState, m_TryModel);
            }
        }

        private void DoTreeView()
        {
            m_MyTreeView1.OnGUI(treeViewRect);
        }
    #endregion OnGUI!

    private void OnSelectTreeAsset()
    {
        lastSelectedTreeAssetName = m_MyTreeAsset.name;
        isNeedReloadData = true;
    }

    // [OnOpenAsset]
    // public static bool OnOpenAsset (int instanceID, int line)
    // {
    //     var myTreeAsset = EditorUtility.InstanceIDToObject (instanceID) as MyTreeAsset1;
    //     if (myTreeAsset != null)
    //     {
    //         var window = GetWindow();
    //         window.SetTreeAsset(myTreeAsset);
    //         return true;
    //     }
    //     return false; // we did not handle the open
    // }
}
