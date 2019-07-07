using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    public static PrefabSpawner instance;

    Object flyingEnemyPrefab;
    Object coinPrefab;

    [SerializeField]
    private int minimumCount = 0;
    [SerializeField]
    private int maximumCount = 2;

    private void Awake()
    {
        flyingEnemyPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Enemies/FlyingEnemy.prefab", typeof(GameObject));
        coinPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Coin.prefab", typeof(GameObject));
        if (instance != null)
        {
            Destroy(gameObject); //if an instance already exists destry this one...
        }
        else
        {
            instance = this; ////...otherwise take it...
            DontDestroyOnLoad(gameObject); //...and keep alive.
        }
        InvokeRepeating("Spawn_DELETE_ME", 0, 5);
    }

    public int MinimumCount
    {
        get { return this.minimumCount; }
        set { this.minimumCount = value; }
    }
    public int MaximumCount
    {
        get { return this.maximumCount; }
        set { this.maximumCount = value; }
    }

    public void SpawnCoins(Vector2 position)
    {
        // Randomly pick the count of prefabs to spawn.
        int count = Random.Range(this.MinimumCount, this.MaximumCount);
        // Spawn them!
        for (int i = 0; i < count; ++i)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }

    void Spawn_DELETE_ME()
    {
        int count = Random.Range(this.MinimumCount, this.MaximumCount);
        // Spawn them!
        for (int i = 0; i < count; ++i)
        {
            Instantiate(flyingEnemyPrefab, this.transform.position, Quaternion.identity);
        }
    }

}
