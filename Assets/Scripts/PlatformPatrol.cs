using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour {

    [SerializeField]
    private Transform minPatrolObject;
    [SerializeField]
    private Transform maxPatrolObject;
    [SerializeField]
    private bool shouldGoLeft;

    [SerializeField]
    private bool shouldFlipOnChangeSides;

    [SerializeField]
    private bool shouldGoDown;

    [SerializeField]
    private Vector3 moveY;

    [SerializeField]
    private Vector3 moveX;

    public enum MoveDirection { MoveUpDown, MoveLeftRight }

    [SerializeField]
    public MoveDirection moveDirection;

    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (moveDirection == MoveDirection.MoveLeftRight)
        {
            if (shouldGoLeft == true)
            {
                transform.position += (-moveX * Time.deltaTime);
                if (minPatrolObject.position.x > gameObject.transform.position.x)
                {
                    shouldGoLeft = false;
                    //If platform should flip on changing sides - flip
                    if (shouldFlipOnChangeSides == true)
                    {
                        gameObject.transform.Rotate(0, 180, 0);
                    }
                }
            }
            else if (shouldGoLeft == false)
            {
                transform.position += (moveX * Time.deltaTime);
                if (maxPatrolObject.position.x < gameObject.transform.position.x)
                {
                    shouldGoLeft = true;
                    //If platform should flip on changing sides - flip
                    if (shouldFlipOnChangeSides == true)
                    {
                        gameObject.transform.Rotate(0, -180, 0);
                    }
                }
            }
        }
        else if (moveDirection == MoveDirection.MoveUpDown)
        {
            if (shouldGoDown == true)
            {
                transform.position += (-moveY * Time.deltaTime);
                if (minPatrolObject.position.y > gameObject.transform.position.y)
                {
                    shouldGoDown = false;
                }
            }
            else if (shouldGoDown == false)
            {
                transform.position += (moveY * Time.deltaTime);
                if (maxPatrolObject.position.y < gameObject.transform.position.y)
                {
                    shouldGoDown = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Player" && other.transform.position.y > gameObject.transform.position.y)
        {
            Debug.Log("set parent");
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.name == "Player")
        {
            other.collider.transform.SetParent(null);
        }
    }

}
