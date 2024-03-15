using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

class MyTreeViewOrigin : CustomHeightTreeView<MyTreeElementOrigin>//TreeViewByModel<MyTreeElementOrigin>
{
    public MyTreeViewOrigin(TreeViewState state, TreeModel<MyTreeElementOrigin> model) : base(state, model)
    {
    }
}