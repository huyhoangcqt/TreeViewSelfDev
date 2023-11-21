using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MyTreeAsset2", menuName = "TreeViewSelfDev/MyTreeAsset2", order = 0)]
public class MyTreeAsset2 : MyTreeAsset<MyTreeElement2> {
    [SerializeField] public  List<MyTreeElement2> elements = new List<MyTreeElement2>();

    private void Awake() {
        elements = TreeAssetAutoGenerate.Generate<MyTreeElement2>(maxItem: 100, maxDepth: 3);
    }
}