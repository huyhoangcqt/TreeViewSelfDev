using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TreeAssetAutoGenerate
{
    public const int MAX_CHILD_ITEM = 10;
    private static System.Random randomExt;

    public static List<T> Generate<T>(int maxItem, int maxDepth) where T : TreeElement, new()
    {
        randomExt = new System.Random(DateTime.Now.Millisecond);

        List<T> result = new List<T>();
        T m_root = RandomSingle<T>(ref result, -1);
        int crrDepth = 0;

        while (true){
            RandomOne<T>(m_root, maxItem, maxDepth, ref result, crrDepth);
            if (result.Count >= maxItem){
                return result;
            }
        }
    }

    private static void RandomOne<T>(T parent, int maxItem, int maxDepth, ref List<T> result, int crrDepth) where T : TreeElement, new ()
    {
        Debug.Log("Result count: " + result.Count);
        if (result.Count >= maxItem || crrDepth > maxDepth){
            return;
        }

        if (parent == null)
        {
            parent = RandomSingle<T>(ref result, crrDepth, name: "Root");
            crrDepth++;
            RandomOne<T>(parent, maxItem, maxDepth, ref result, crrDepth);
            return;
        }

        var childCount = randomExt.Next(0, MAX_CHILD_ITEM);
        if (childCount + result.Count >= maxItem){
            childCount = maxItem - result.Count;
        }

        int count = 0;
        while (true)
        {
            var node = RandomSingle<T>(ref result, crrDepth);
            parent.AddChild(node);
            node.SetParent(parent);
            RandomOne<T>(node, maxItem, maxDepth, ref result, crrDepth + 1);
            
            count++;
            if (count >= childCount || result.Count >= maxItem){
                return;
            }
        }
    }

    private static T RandomSingle<T>(ref List<T> result, int crrDepth, string name = null) where T : TreeElement, new()
    {
        if (name == null){
            name = GenerateName();
        }
        T item = new T();
        item.m_Id = result.Count;
        item.m_Depth = crrDepth;
        item.m_DisplayName = name;
        item.AutoGenerate();
        result.Add(item);
        return item;
    }

    public static string GenerateName()
    {
        int len = UnityEngine.Random.Range(0, 11);
        {
            return "Folder " + GenerateName(len);
        }
    }

    public static string GenerateName(int len)
    { 
        // System.Random randomExt = new System.Random();

        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y", "ee", "ua", "ue", "oo", "ai", "ie", "ay", "uye", "uya"};
        string Name = "";
        Name += consonants[randomExt.Next(consonants.Length)].ToUpper();
        Name += vowels[randomExt.Next(vowels.Length)];
        int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        while (b < len)
        {
            Name += consonants[randomExt.Next(consonants.Length)];
            b++;
            Name += vowels[randomExt.Next(vowels.Length)];
            b++;
        }

        return Name;
     }
}