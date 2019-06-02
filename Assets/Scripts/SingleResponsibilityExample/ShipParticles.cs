using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParticles : MonoBehaviour
{
    [SerializeField]
    private GameObject thrusterParticles;
    [SerializeField]
    private GameObject deathParticleSystemPrefab;

    void Awake()
    {
        GetComponent<ShipEngine>().ThrustChanged += HandleThrustChanged;
        GetComponent<ShipHealth>().OnDie += HandleShipDeath;
    }
    private void HandleThrustChanged(float thrust)
    {
        thrusterParticles.SetActive(thrust > 0f);
        //scale the particle based on the thrust here
    }

    private void HandleShipDeath()
    {
        Instantiate(deathParticleSystemPrefab, transform.position, Quaternion.identity);
    }
}
