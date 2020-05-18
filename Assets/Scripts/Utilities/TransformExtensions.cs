using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void ClearAll(this Transform item)
    {
        GameObject[] childs = new GameObject[item.childCount];
        int i = 0;
        foreach(Transform children in item)
        {
            childs[i] = children.gameObject;
            i += 1;
        }

        foreach(var children in childs)
        {
            GameObject.Destroy(children);
        }
    }
}
