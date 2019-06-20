using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string poolTag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        #endregion

        #region Instantiate and prepare the object queues
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.poolTag, objectPool);
        }
        #endregion
    }

    public GameObject SpawnFromPool(string tag, Vector2 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Pool with specified tag " + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }
        else
        {
            Debug.LogError("Pooled object didn't had IPooledObject interface");
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
