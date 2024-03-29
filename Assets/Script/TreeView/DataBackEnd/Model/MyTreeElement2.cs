using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;

[Serializable]
public enum EType
{
    File,
    Folder,
}

[Serializable]
public class MyTreeElement2 : TreeElement
{
    public float m_DataSize;
    public EType m_Type;
    public int rare { get { return m_Rare; } set { m_Rare = Mathf.Clamp(value, 0, 5); } }
    [SerializeField, Range(0, 5)]
    private int m_Rare;
    
    public MyTreeElement2() : base()
    {
    }

    public MyTreeElement2(int id, int depth, string name) : base(id, depth, name)
    {
    }

    public MyTreeElement2(int id, int depth, string name, float size, int type) : base(id, depth, name)
    {
        m_DataSize = size;
        m_Type = (EType)type;
    }
}