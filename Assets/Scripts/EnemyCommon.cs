using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    public void Die()
    {
        ParticleManager.instance.EnemyDeadEmit(gameObject.transform.position);
        PrefabSpawner.instance.SpawnCoins(gameObject.transform.position);
    }
}
