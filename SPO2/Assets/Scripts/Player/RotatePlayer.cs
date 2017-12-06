using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {
    bool left;
    public float speed = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            left = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }

        if (left == false)
        {
            transform.Rotate(Vector3.up * speed*Time.deltaTime, Space.World);
        }
	}
}
