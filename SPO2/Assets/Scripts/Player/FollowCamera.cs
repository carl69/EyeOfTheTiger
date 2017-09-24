using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	//public GameObject Tiger;
	public float Smooth = 10.0f;
	float x,y;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
	    y = GameObject.FindGameObjectWithTag("Player").transform.position.y ;
		Vector3 aux = new Vector3 (x, y+7, transform.position.z);

	}
	
	// Update is called once per frame

	void FixedUpdate () {

		x = transform.position.x +(  GameObject.FindGameObjectWithTag("Player").transform.position.x -transform.position.x)/Smooth;

		Vector3 aux = new Vector3 (x, transform.position.y, transform.position.z);
		transform.position = aux;

	}
}
