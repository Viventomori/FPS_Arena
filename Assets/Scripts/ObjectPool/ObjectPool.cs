using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   private GameObject prefab;
    private int maxObjects;
    private List<GameObject> objects;

    public void Initialize(GameObject prefab, int maxObjects)
    {
        this.prefab = prefab;
        this.maxObjects = maxObjects;
        objects = new List<GameObject>();

        for (int i = 0; i < maxObjects; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        objects.Add(newObj);
        return newObj;
    }
}