using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTargetFollow : MonoBehaviour {
    public float curentDistance;
    public float maxDistance;
    public float speed;
    public float timeBeforeIdel;
    public float timer;
    public float leftRight;
	// Use this for initialization
	void Start () {
        leftRight = Input.GetAxis("Horizontal");

    }

    // Update is called once per frame
    void FixedUpdate () {
        if (timer < timeBeforeIdel)
        {
            timer += Time.deltaTime;
        }
        else
        {
            leftRight = Input.GetAxis("Horizontal");


        }

        if (/*Input.GetAxis("Horizontal") != 0*/Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        {
            timer = 0;
            leftRight = Input.GetAxis("Horizontal");
            curentDistance += leftRight * speed;

            if (curentDistance < maxDistance || curentDistance > -maxDistance)
            {
                curentDistance = maxDistance * leftRight;
                transform.localPosition = new Vector3(curentDistance, 0, 0);

            }
        }

	}

}
