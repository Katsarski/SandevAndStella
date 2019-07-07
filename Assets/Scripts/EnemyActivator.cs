using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemies;

    public enum ActivateWhat { EnemyProjectileActivator, EnemyPatrolActivator }

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    public ActivateWhat activator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (activator == ActivateWhat.EnemyPatrolActivator)
            {
                ActivateEnemyPatrol();
            }
            else if(activator == ActivateWhat.EnemyProjectileActivator)
            {
                ActivateEnemyProjectileActivator();
            }
        }
    }

    private void ActivateEnemyProjectileActivator()
    {
        //Need to see if we need this ...
        //spawnPoint.gameObject.GetComponent<PrefabSpawner>().Spawn();
    }

    private void ActivateEnemyPatrol()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            try
            {
                enemies[i].GetComponent<EnemyPatrol>().enabled = true;
            }
            catch (MissingReferenceException ex)
            {

                throw ex;
            }
        }
    }

}
