using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEditor;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    public static PrefabSpawner instance;

    public GameObject CoinsPool;

    public GameObject CoinPrefab;

    [SerializeField]
    private int minimumCoinCount = 0;
    [SerializeField]
    private int maximumCoinCount = 2;

    LeanGameObjectPool pool;

    private void Awake()
    {
        instance = this;
        pool = CoinsPool.GetComponent<LeanGameObjectPool>();
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
                LeanPool.Spawn(CoinPrefab, position, Quaternion.identity);
                //pool.Spawn(position, Quaternion.identity);
                //Instantiate(coinPrefab, position, Quaternion.identity);
            }
            catch (System.Exception)
            {
                Debug.LogError("Could not spawn prefab");
            }
        }
    }
}
