using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	public GameObject Tiger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Tiger.transform.position.x;
		float y = Tiger.transform.position.y;
		Vector3 aux = new Vector3 (x, y+7, transform.position.z);
		transform.position = aux;

	}
}
