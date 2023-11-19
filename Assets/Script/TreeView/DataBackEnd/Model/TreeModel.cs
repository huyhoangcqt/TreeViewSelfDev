using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using System;

public class TreeModel<T> where T : TreeElement
{
    public List<T> elements;

    public TreeModel(List<T> ele)
    {
        Debug.Log("TreeModel > element count: " + ele.Count);
        elements = new List<T>();
        elements.AddRange(ele);
    }
}