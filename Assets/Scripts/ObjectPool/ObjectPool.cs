using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singletion<ObjectPool>
{
    private List<GameObject> pooledPipeObjects = new List<GameObject>();

    [SerializeField] private int amountPool = 10;

    [SerializeField] private GameObject _pipePrefab;
    
    private void Start()
    {
        for (int i = 0; i < amountPool; i++)
        {
            GameObject obj = Instantiate(_pipePrefab);
            obj.SetActive(false);
            pooledPipeObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledPipeObjects.Count; i++)
        {
            if (!pooledPipeObjects[i].activeInHierarchy)
            {
                return pooledPipeObjects[i];
            }
        }

        return null;
    }
}