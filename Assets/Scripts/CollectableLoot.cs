using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Lean.Pool;

public class CollectableLoot : MonoBehaviour {


    [SerializeField]
    private int destroyAfterTime = 5;

    [SerializeField]
    private float isPickableAfter = 0.5f;
    [SerializeField]
    private int reward;
    [SerializeField]
    private int minPushYForceVelocity = 4;
    [SerializeField]
    private int maxPushYForceVelocity = 7;
    [SerializeField]
    private int minPushXForceVelocity = -1;
    [SerializeField]
    private int maxPushXForceVelocity = 1;


    private void Awake()
    {
        if (gameObject.tag == "FloatingCoin")
        {

        }
        else
        {
           gameObject.GetComponent<Rigidbody2D>().velocity =
           (new Vector2(Random.Range(this.minPushXForceVelocity, this.maxPushXForceVelocity),
           Random.Range(this.minPushYForceVelocity, this.maxPushYForceVelocity))) *
           Random.Range(this.minPushYForceVelocity, this.maxPushYForceVelocity);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //&& isPickable = true;
        if (other.gameObject.name == "Player")
        {
            PlayerCollects.instance.CollectCoins(reward);
            LeanPool.Despawn(this);
        }
    }
}
