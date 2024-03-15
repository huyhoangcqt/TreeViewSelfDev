using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;

[Serializable]
public class MyTreeElementOrigin : TreeElement
{

    public MyTreeElementOrigin() : base()
    {
    }

    public MyTreeElementOrigin(int id, int depth, string name) : base(id, depth, name)
    {
    }
}