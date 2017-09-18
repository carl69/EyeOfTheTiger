using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {
	public bool drinking = false;
	public int drink = 100;

    private float rate = 2;
    public float timer;
	// Use this for initialization
	void Start () {

	}

    void Update() {

        if (drinking == true)
        {
            if (drink < 200)
            {
                drink++;
            }
        }
        else if (timer < Time.time)
        {
            timer = Time.time + rate;
            drink--;
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

