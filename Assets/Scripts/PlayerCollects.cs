using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollects : MonoBehaviour {

    private int coins;
    public static PlayerCollects instance = null;

    // Use this for initialization
    void Start () {
        instance = this;
        Debug.Log("Number of coins: " + coins);
	}
	
    public void CollectCoins(int coinsCollected)
    {
        coins += coinsCollected;
    }

    public int GetCoins()
    {
        return coins;
    }
}
