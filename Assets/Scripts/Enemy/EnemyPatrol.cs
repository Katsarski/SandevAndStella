using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    [SerializeField]
    private Transform minXObject;
    [SerializeField]
    private Transform maxXObject;
    [SerializeField]
    private bool shouldGoLeft;
    [SerializeField]
    private int moveSpeed;

    private Rigidbody2D myRigidbody;

    private Vector2 negativeX;
    private Vector2 positiveX;


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        negativeX = new Vector2(-moveSpeed, 0);
        positiveX = new Vector2(moveSpeed, 0);

    }

    private void Update()
    {
        if (shouldGoLeft == true)
        {
            gameObject.transform.rotation = new Quaternion(0, -180, 0, 0);
            myRigidbody.velocity = negativeX;
            if (minXObject.position.x > gameObject.transform.position.x)
            {
                shouldGoLeft = false;
            }
        }
        else if (shouldGoLeft == false)
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            myRigidbody.velocity = positiveX;
            if (maxXObject.position.x < gameObject.transform.position.x)
            {
                shouldGoLeft = true;
            }
        }

    }
}
