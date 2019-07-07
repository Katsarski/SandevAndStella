using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStatic : MonoBehaviour {

    [SerializeField]
    private int reward;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //&& isPickable = true;
        if (other.gameObject.name == "Player")
        {
            PlayerCollects.instance.CollectCoins(reward);
            gameObject.SetActive(false);
        }
    }
}
