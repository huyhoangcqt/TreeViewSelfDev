using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

class TreeViewByModel<T> : TreeView where T : TreeElement
{
    #region Attributes
        TreeModel<T> m_Model;
        private TreeViewItem m_Root;
        private List<TreeViewItem> m_AllItems;
    #endregion Attributes!

    public TreeViewByModel(TreeViewState treeViewState, TreeModel<T> model) : base(treeViewState)
    {
        m_Model = model;
        showBorder = true;
        InitData();
        Reload();
    }

    private void InitData()
    {
        // m_Root = new TreeViewItem<T>(0, -1, "root", null);
        var dataRoot = m_Model.elements[0];
        m_Root = new TreeViewItem<T>(0, -1, dataRoot.m_DisplayName, dataRoot);
        m_AllItems = new List<TreeViewItem>();
        Debug.Log("TreeViewByModel >> InitData > elements Count: " + m_Model.elements.Count);
        for (int i = 1; i < m_Model.elements.Count; i++){
            var treeElement = m_Model.elements[i];
            var item = new TreeViewItem<T>(treeElement.m_Id, treeElement.m_Depth, treeElement.m_DisplayName, treeElement);
            m_AllItems.Add(item);
        }
    }
        
    protected override TreeViewItem BuildRoot ()
    { 
        // Utility method that initializes the TreeViewItem.children and .parent for all items.
        SetupParentsAndChildrenFromDepths (m_Root, m_AllItems);
            
        // Return root of the tree
        return m_Root;
    }
}