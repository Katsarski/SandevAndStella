using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    private int health;

    public event Action OnDie = delegate { };
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {
       //This has to be a Projectile script attached to a GameObject (+ drag it in the inspector if needby)
       //var projectile = col.collider.GetComponent<Projectile>();
       //if (projectile != null)
       //{
       //    TakeDamage(projectile.Damage);
       //}
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        OnDie();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
