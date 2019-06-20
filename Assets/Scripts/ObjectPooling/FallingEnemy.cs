using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        Debug.Log("Falling enemy was spawned");
    }
}
