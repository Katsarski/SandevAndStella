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
    private int minimumCoinCount = 0;
    [SerializeField]
    private int maximumCoinCount = 2;

    private void Awake()
    {
        try
        {
            flyingEnemyPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Enemy/FlyingEnemy.prefab", typeof(GameObject));
            coinPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Collectables/Coin.prefab", typeof(GameObject));
        }
        catch (System.Exception)
        {
            Debug.LogError("The prefab could not be found: Check the path where we try to get it");
            throw;
        }
        
        if (instance != null)
        {
            Destroy(gameObject); //if an instance already exists destry this one...
        }
        else
        {
            instance = this; ////...otherwise take it...
            DontDestroyOnLoad(gameObject); //...and keep alive.
        }
    }

    public int MinimumCount
    {
        get { return this.minimumCoinCount; }
        set { this.minimumCoinCount = value; }
    }
    public int MaximumCount
    {
        get { return this.maximumCoinCount; }
        set { this.maximumCoinCount = value; }
    }

    public void SpawnCoins(Vector2 position)
    {
        // Randomly pick the count of prefabs to spawn.
        int count = Random.Range(this.MinimumCount, this.MaximumCount);
        // Spawn them!
        for (int i = 0; i < count; ++i)
        {
            try
            {
                Instantiate(coinPrefab, position, Quaternion.identity);
            }
            catch (System.Exception)
            {
                Debug.LogError("The prefab could not be found: Check the path where we try to get it");
                throw;
            }
        }
    }
}
