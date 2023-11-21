using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MyTreeAsset1", menuName = "TreeViewSelfDev/MyTreeAsset1", order = 0)]
public class MyTreeAsset1 : MyTreeAsset<MyTreeElement1> 
{
    private void Awake() {
        elements = TreeAssetAutoGenerate.Generate<MyTreeElement1>(maxItem: 100, maxDepth: 3);
    }
}
