using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonObject {
    Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();
    public GameObject prefab;
    public int poolSize;

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        int poolKey = prefab.GetInstanceID();

        if (!pool.ContainsKey(poolKey))
        {
            pool.Add(poolKey, new Queue<GameObject>());

            for (int i = 0; i < poolSize; i++)
            {
                GameObject newObject = Instantiate(prefab) as GameObject;
                newObject.SetActive(false);
                pool[poolKey].Enqueue(newObject);
            }
        }
    }

    public void ReuseObject(Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();

        if (pool.ContainsKey(poolKey))
        {
            GameObject objectToReuse = pool[poolKey].Dequeue();
            pool[poolKey].Enqueue(objectToReuse);

            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
        }
    }
}
