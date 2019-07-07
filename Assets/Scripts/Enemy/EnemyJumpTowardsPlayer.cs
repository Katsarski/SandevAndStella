using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpTowardsPlayer : MonoBehaviour {

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private Transform playerToFollow;

    [SerializeField]
    private int moveSpeed;

    [SerializeField]
    private int jumpEveryHowManySeconds;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InvokeRepeating("JumpTowardsPlayer",2, jumpEveryHowManySeconds);
    }

    void JumpTowardsPlayer()
    {
        if (gameObject.transform.position.x < playerToFollow.position.x)
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 5);
        }
        else if (gameObject.transform.position.x > playerToFollow.position.x)
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 5);

        }
    }

}
