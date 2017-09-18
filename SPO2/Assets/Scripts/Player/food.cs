using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {
	public int eaten = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "food") {
			eaten++;
			Destroy (other.gameObject);
		}

	}

	void OnGUI (){
		GUILayout.Label ("food =" + eaten);
	}
}
