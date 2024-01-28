using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// [CreateAssetMenu(fileName = "MyTreeAsset", menuName = "TreeViewSelfDev/MyTreeAsset", order = 0)]
public class MyTreeAsset<T> : ScriptableObject where T : TreeElement
{
    [SerializeField] public List<T> elements = new List<T>();

    // private void Awake() {
    //     SelfGenerate();
    // }

    // private void SelfGenerate()
    // {
    //     Debug.Log("SelfGenerate");
    //     List<TreeElement> result = TreeAssetAutoGenerate.Generate<TreeElement>(maxItem: 100, maxDepth: 3);
    //     if (result != null){
    //         elements = new List<T>();
    //         foreach (var element in result){
    //             if (element != null && (element as T) != null){
    //                 elements.Add(element as T);
    //             }
    //         }
    //     }
    // }
}