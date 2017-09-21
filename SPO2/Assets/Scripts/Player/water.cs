using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water : MonoBehaviour {
	private bool drinking = false;
	public int drink = 50;
    public int MaxWater = 100;
    // how fast you lose water
    public float rate = 2;
    private float timer;
	public GameObject button;
	int counter = 0;
    void Update() {

        if (drinking == true)
        {
            if (drink < MaxWater)
            {
                drink++;
            }
        }
        else if (timer < Time.time)
        {
            timer = Time.time + rate;
            drink--;

			if (drink == 0){
				button.SetActive (true);
				drink = 0;
				counter = 30;
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;

      
			}
            
        }
		if (counter > 0) {
			counter--;
			transform.RotateAround (transform.position, new Vector3 (1, 0, 0), 3);
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
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
		
}

