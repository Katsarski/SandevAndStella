using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsBehavior : MonoBehaviour {


    float sawSpeed = 300;


    private void Update()
    {
        transform.Rotate(0, 0, sawSpeed * Time.deltaTime);
    }
    

}
