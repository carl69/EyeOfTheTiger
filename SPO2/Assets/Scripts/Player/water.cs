using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water : MonoBehaviour {
	private bool drinking = false;
    public float drink = 50;
    [HideInInspector]
    public float MaxWater = 100;
    private float lossAmount;
    private float gain;
    // how fast you lose water
    private float rate = 2;
    private float timer;
	public GameObject button;
	int counter = 0;
    playerStats Playstats;
    void Start()
    {
        Playstats = GameObject.Find("Player").GetComponent<playerStats>();
        MaxWater = Playstats.maxWater;
        drink = Playstats.startWater;
        gain = Playstats.waterPickUp;
        rate = Playstats.waterLossRate;
        lossAmount = Playstats.waterLossAmount;
    }

void Update() {
        if (drinking == true)
        {
            if (drink < MaxWater)
            {
                drink+= gain;
            }
        }
        else if (timer < Time.time)
        {
            timer = Time.time +rate;
            drink-= lossAmount;

			if (drink <= 0){
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

