using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	//public GameObject Tiger;
	public float Smooth = 10.0f;
	float counter = 0.0f;
	float x;//,y;

	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
		//y = GameObject.FindGameObjectWithTag("Player").transform.position.y ;
		//Vector3 aux = new Vector3 (x, y+7, transform.position.z);

	}

	// Update is called once per frame

	void FixedUpdate () {

        //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        //{
        //    if (counter <= 23) counter++;
        //    x = (GameObject.FindGameObjectWithTag("Player").transform.position.x);

        //    Vector3 aux2 = new Vector3(x, transform.position.y, transform.position.z);
        //    transform.position = aux2;
        //    transform.localRotation = Quaternion.Euler(0.0f, counter, 0.0f);

        //}
        //else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        //{
        //    if (counter <= 23) counter++;

        //    x = (GameObject.FindGameObjectWithTag("Player").transform.position.x);

        //    Vector3 aux3 = new Vector3(x, transform.position.y, transform.position.z);
        //    transform.position = aux3;
        //    transform.localRotation = Quaternion.Euler(0.0f, -counter, 0.0f);

        //}
        //else {
			if(counter >0)counter-=5;
			if(counter <=0) counter = 0 ;
			x = transform.position.x + (GameObject.FindGameObjectWithTag ("Player").transform.position.x - transform.position.x) / Smooth;

			Vector3 aux = new Vector3 (x, transform.position.y, transform.position.z);
			transform.position = aux;
			transform.localRotation = Quaternion.Euler(0.0f, counter, 0.0f);
		//}
	}
}



