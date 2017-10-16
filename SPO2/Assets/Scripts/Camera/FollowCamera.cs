using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	//public GameObject Tiger;
	public float Smooth = 10.0f;
	public float counter = 0.0f, counter2 = 0.0f ;
	float x, z, y, yy , zz;
    public Vector3 startPos;

	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        startPos = gameObject.transform.position;
		//Vector3 aux = new Vector3 (x, y+7, transform.position.z);

	}

	// Update is called once per frame

	void FixedUpdate () {

		if (Input.GetAxis("Horizontal") > 0 && Input.GetKey(KeyCode.LeftShift))
		{
			if (Input.GetKey (KeyCode.LeftShift)) {
				/*if (counter <= 90) counter++;
			if (counter2 <= 2) counter2 = counter2 = counter2;*/
				x = (GameObject.FindGameObjectWithTag ("Player").transform.position.x - 7);
				y = (GameObject.FindGameObjectWithTag ("Player").transform.position.y + 2);
				z = (GameObject.FindGameObjectWithTag ("Player").transform.position.z - 3);


				Vector3 aux2 = new Vector3 (x, y /*transform.position.y*/, z /*transform.position.z*/);
				transform.position = aux2;
				transform.localRotation = Quaternion.Euler (0.0f, 90/*counter*/, 0.0f);
			}

		}
		else if (Input.GetAxis("Horizontal") < 0 && Input.GetKey(KeyCode.LeftShift))
		{

			/*if (counter >= -90) counter--;
			if (counter2 >= 10) counter2++;*/
			x = (GameObject.FindGameObjectWithTag("Player").transform.position.x + 7 );
			y = (GameObject.FindGameObjectWithTag("Player").transform.position.y + 2 );
			z = (GameObject.FindGameObjectWithTag("Player").transform.position.z - 3 );


			Vector3 aux3 = new Vector3(x, y/*transform.position.y*/,z /*transform.position.z*/);
			transform.position = aux3;
			transform.localRotation = Quaternion.Euler(0.0f, -90 /*counter*/, 0.0f);

		}


		else
		{
			/*	if (counter >0)counter-=2;
			if (counter <0)counter+=2;
			if(-4 <= counter && counter <=4) counter = 0 ;

			if (counter2 >0)counter2--;
			if (counter2 <0)counter2++;
			if(-1 <= counter2 && counter2 <=1) counter2 = 0 ;*/
			print (transform.position.z);
			x = transform.position.x + (GameObject.FindGameObjectWithTag ("Player").transform.position.x - transform.position.x) / Smooth;
			zz = startPos.z;
			yy = startPos.y;
			Vector3 aux = new Vector3 (x,yy /*transform.position.y*/ , zz/*transform.position.z*/);
			transform.position = aux;
			transform.localRotation = Quaternion.Euler(5.0f,0.0f /*counter*/, 0.0f);
		}
	}
}

