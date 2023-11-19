using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

class MyTreeView1 : CustomHeightTreeView<MyTreeElement1>//TreeViewByModel<MyTreeElement1>
{
    public MyTreeView1(TreeViewState state, TreeModel<MyTreeElement1> model) : base(state, model)
    {
    }
}