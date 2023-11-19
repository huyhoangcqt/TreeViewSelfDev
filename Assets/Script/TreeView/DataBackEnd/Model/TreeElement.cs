using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;

// [Serializable]
public class TreeElement
{
    public int m_Id;
    public int m_Depth;
    public string m_DisplayName;
    List<TreeElement> m_Children;
    TreeElement m_Parent;


    public TreeElement()
    {
        m_Id = 0;
        m_Depth = 0;
        m_DisplayName = string.Empty;
        m_Children = new List<TreeElement>();
        m_Parent = null;
    }

    public TreeElement(int id, int depth, string name)
    {
        m_Id = id;
        m_Depth = depth;
        m_DisplayName = name;
        m_Children = new List<TreeElement>();
        m_Parent = null;
    }

    public void AddChild(TreeElement child)
    {
        m_Children.Add(child);
    }

    public void SetParent(TreeElement parent){
        m_Parent = parent;
    }

    public virtual void AutoGenerate()
    {
        
    }
}
