using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public static AsteroidPool sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject asteroidPrefab; 
    private int amountToPool = 8;

    void Awake()
{   
    sharedInstance = this;
}

void Start()
{
    pooledObjects = new List<GameObject>();
    GameObject tmp;
    for(int i = 0; i < amountToPool; i++)
    {
        tmp = Instantiate(asteroidPrefab);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
    }
}

public GameObject GetPooledObject()
{
    for(int i = 0; i < amountToPool; i++)
    {
        if(!pooledObjects[i].activeInHierarchy)
        {
            return pooledObjects[i];
        }
    }
    return null;
}

}


// https://learn.unity.com/tutorial/introduction-to-object-pooling# Her lærte jeg pooling:)