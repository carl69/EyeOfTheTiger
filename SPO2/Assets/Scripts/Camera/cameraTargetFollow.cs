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

    public float lastPos;
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

		if (Input.GetAxis ("Horizontal") != 0/*Input.GetAxis ("Horizontal") > 0*/) {
			timer = 0;
			leftRight = Input.GetAxis ("Horizontal");

			//print (Input.GetAxis ("Horizontal"));
			if (Mathf.Abs (curentDistance) <= maxDistance) {
				curentDistance += leftRight * speed * Time.deltaTime;

				transform.localPosition = new Vector3 (curentDistance, 0, 0); 
				lastPos = curentDistance;

			}
			if (curentDistance > 9 && Input.GetAxis ("Horizontal") < 0) {

				curentDistance = 0;
				transform.position = Vector3.MoveTowards(this.transform.position, transform.parent.position, speed * Time.deltaTime);
				curentDistance = -10;

			}
			if (curentDistance < -9 && Input.GetAxis ("Horizontal") > 0) {

				curentDistance = 0;
				transform.position = Vector3.MoveTowards(this.transform.position, transform.parent.position, speed * Time.deltaTime);
				curentDistance = 10;

			}

		}
        else if(timer > timeBeforeIdel)
        {
            curentDistance = 0;
            transform.position = Vector3.MoveTowards(this.transform.position, transform.parent.position, speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = new Vector3(lastPos, 0, 0);
        }

	}

}
