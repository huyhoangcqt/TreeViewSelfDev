using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MyTreeAsset", menuName = "TreeViewSelfDev/MyTreeAsset", order = 0)]
public class MyTreeAsset<T> : ScriptableObject where T : TreeElement
{
    [SerializeField] public List<T> elements = new List<T>();

    // private void Awake() {
    //     elements = TreeAssetAutoGenerate.Generate<T>(maxItem: 100, maxDepth: 3);
    // }
}