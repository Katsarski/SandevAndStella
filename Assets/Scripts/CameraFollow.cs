using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    [SerializeField]
    private int yOffset;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private Transform target;

	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y+yOffset, yMin, yMax), transform.position.z);
	}
}
