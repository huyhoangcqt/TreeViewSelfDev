using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyCollection/MyCollection")]
[System.Serializable]
public class MyCollection : ScriptableObject
{
    [System.Serializable]
    public class Element
    {
        // Define properties for each element in the collection
        public int intValue;
        public GameObject gameObjectValue;
        // Add more properties as needed
    }

    public Element[] elements;
}