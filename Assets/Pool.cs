using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolIdentity
{
    public string poolName;
    public int initAmount;
    public GameObject spawnObject;
    public List<GameObject> availableObjects;
    public Pool mainPool;
    
    public void PopulatePool()
    {
        for (int i = 0; i < initAmount; i++)
        {
            var o = 
                mainPool.CreateObject(spawnObject);
            if (o.GetComponent<PooledObject>() == null)
                o.AddComponent<PooledObject>();
            
            o.GetComponent<PooledObject>().parentPool = this;
            availableObjects.Add(o);
            o.SetActive(false);
        }
    }
    
    public void MakeAvailable(GameObject incoming)
    {
        if (!availableObjects.Contains(incoming))
        {
            availableObjects.Add(incoming);
        }
    }

    public GameObject GetNextAvailable()
    {
        if(availableObjects.Count == 0)
            PopulatePool();
        var r = availableObjects[0];
        availableObjects.Remove(r);
        return r;
    }
}

public class Pool : MonoBehaviour
{
    public PoolIdentity[] pools;

    private void Start()
    {
        foreach (var pool in pools)
        {
            pool.PopulatePool();
        }
    }

    public GameObject CreateObject(GameObject prefab)
    {
        return Instantiate(prefab, this.transform);
    }
    
    public GameObject GetObject(string targetPool)
    {
        foreach(var pool in pools)
            if (pool.poolName == targetPool)
                return pool.GetNextAvailable();
        return null;
    }
}
