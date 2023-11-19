using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MyTreeAsset1", menuName = "TreeViewSelfDev/MyTreeAsset1", order = 0)]
public class MyTreeAsset1 : ScriptableObject {
    [SerializeField] public List<MyTreeElement1> elements = new List<MyTreeElement1>();

    private void Awake() {
        elements = TreeAssetAutoGenerate.Generate<MyTreeElement1>(maxItem: 100, maxDepth: 3);
    }
}