using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;

[Serializable]
public enum FileType
{
    File,
    Folder,
}

[Serializable]
public class MyTreeElement1 : TreeElement
{
    public float m_DataSize;
    public FileType m_Type;

    public MyTreeElement1() : base()
    {
    }

    public MyTreeElement1(int id, int depth, string name) : base(id, depth, name)
    {
    }

    public MyTreeElement1(int id, int depth, string name, float size, int type) : base(id, depth, name)
    {
        m_DataSize = size;
        m_Type = (FileType)type;
    }

    public override void AutoGenerate()
    {
        m_DataSize = 0;
        m_Type = FileType.Folder;
    }
}