using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    [SerializeField]
    private Transform player;
    [SerializeField]
    public float moveSpeed;

    private void Start()
    {
        if (player.position.x < gameObject.transform.position.x)
        {
            InvokeRepeating("FlyToTheLeft", 0, 0.005f);
        }
        else
        {
            InvokeRepeating("FlyToTheRight", 0, 0.005f);
        }
        
    }

    void FlyToTheRight()
    {

        transform.Translate(Vector2.right * moveSpeed);
        if (transform.position.x > player.transform.position.x + 50)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    void FlyToTheLeft()
    {

        transform.Translate(Vector2.left * moveSpeed);
        if (transform.position.x < player.transform.position.x - 50)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


}
