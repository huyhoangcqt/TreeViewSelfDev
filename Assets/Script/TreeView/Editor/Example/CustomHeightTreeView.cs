using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEditor;

class CustomHeightTreeView<T> : TreeViewByModel<T> where T : TreeElement
{
    public CustomHeightTreeView(TreeViewState state, TreeModel<T> model) : base(state, model)
    {
    }

    public override void OnGUI(Rect rect){
        // Background
        if (Event.current.type == EventType.Repaint)
            DefaultStyles.backgroundOdd.Draw(rect, false, false, false, false);

        // TreeView
        base.OnGUI (rect);
    }
}