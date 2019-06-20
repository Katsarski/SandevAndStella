using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        Vector2 spawnPos = new Vector2(0, 0);
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }

    void SpawnEnemy()
    {
        objectPooler.SpawnFromPool("FallingEnemy", new Vector2(0, 0));
    }
}
