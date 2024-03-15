using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MyTreeAssetOrigin", menuName = "TreeViewSelfDev/MyTreeAssetOrigin", order = 0)]
public class MyTreeAssetOrigin : MyTreeAsset<MyTreeElementOrigin> {
    private void Awake() {
        
        // Debug.Log("MyTreeAsset2 Awake");
        // elements = TreeAssetAutoGenerate.Generate<MyTreeElement>(maxItem: 100, maxDepth: 3);
    }
}