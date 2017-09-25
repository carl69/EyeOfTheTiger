using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour {
    [HideInInspector]
    public float maxFood = 100;
    public float eaten = 50;
    private float amountOfFood = 10;
    // food loss rate
    private float rate;
    private float timer;

    Audio_pickup audio_pickup;

	int counter = 0;
	//public GameObject button;

    playerStats Playstats;
    private void Start()
    {
        Playstats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();
        maxFood = Playstats.maxHunger;
        eaten = Playstats.startHunger;
        amountOfFood = Playstats.foodPickUp;
        rate = Playstats.hungerSpeed;

        audio_pickup = GameObject.Find("PickUps").GetComponent<Audio_pickup>();
    }

    private void Update()
    {

        if (timer < Time.time)
        {
            timer = Time.time + rate;
            eaten--;

            if (eaten <= 0)
            {
				//button.SetActive (true);
				eaten = 0;
				counter = 30;
				//gameObject.GetComponent<Rigidbody> ().gravityScale = 0;
            }
        }

		if (counter > 0) {
			counter--;
			transform.RotateAround (transform.position, new Vector3 (1, 0, 0), 3);
			//gameObject.GetComponent<Rigidbody> ().gravityScale = 0;
		}
    }

    public void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "food" && eaten <= maxFood && Input.GetKeyDown(KeyCode.Space)) {
            if ((maxFood - eaten) <= amountOfFood)
            {
                eaten = maxFood;
            }
            else
            {
                eaten += amountOfFood;
            }
            audio_pickup.isEating = true;
            Destroy (other.gameObject);
		}

	}


}
