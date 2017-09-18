using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
	public bool drinking = false;
	public int drink = 0;

	// Use this for initialization
	void Start () {

	}

	void Update () {
		if (drinking == true){
			drink++;
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "water") {
			drinking = true;
		}
	}


	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "water") {
			drinking = false;
		}
	}

	void OnGUI (){
		GUILayout.Label ("");
		GUILayout.Label ("water =" + drink);
	}
}

