using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleManager : MonoBehaviour
{
    public GameObject bloodSplash;

    public static ParticleManager instance;
    private ParticleSystem[] particleSystemResult;

    void Start()
    {
        instance = this;
    }

    public void EnemyDeadEmit(Vector2 spawnLocation)
    {
        bloodSplash.transform.position = spawnLocation;
        particleSystemResult = bloodSplash.GetComponentsInChildren<ParticleSystem>();
        foreach (var particle in particleSystemResult)
        {
            particle.Play();
        }
    }



}