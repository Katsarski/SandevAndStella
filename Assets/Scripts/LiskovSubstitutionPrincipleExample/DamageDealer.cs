using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DealDamageToNearestCharacter();
        }
    }

    private void DealDamageToNearestCharacter()
    {
        Character nearestCharacter = FindObjectOfType<Character>();
        int damageToDeal = 1;
        nearestCharacter.TakeDamage(damageToDeal);
    }
}
