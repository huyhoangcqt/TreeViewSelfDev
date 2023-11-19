using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

class MyTreeView2 : TreeViewByModel<MyTreeElement2>
{

    public MyTreeView2(TreeViewState state, TreeModel<MyTreeElement2> model) : base(state, model)
    {
    }
}