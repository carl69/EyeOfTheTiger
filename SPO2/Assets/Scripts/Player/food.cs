using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour {
    [HideInInspector]
    public float maxFood = 100;
    [HideInInspector]
    public bool eating = false;
    public float eaten = 50;
    private float amountOfFood = 10;
    // food loss rate
    private float rate;
    private float timer;

    Audio_pickup audio_pickup;

	//int counter = 0;
	//public GameObject button;

    playerStats Playstats;
    private void Start()
    {
        Playstats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();
        maxFood = Playstats.maxHunger;
        eaten = Playstats.startHunger;
        amountOfFood = Playstats.foodPickUp;
        rate = Playstats.hungerSpeed;

        if (GameObject.Find("PickUps") != null)
        {
            audio_pickup = GameObject.Find("PickUps").GetComponent<Audio_pickup>();
        }
    }

    private void Update()
    {
        if (eating)
        {
            eating = false;
        }

        if (timer < Time.time)
        {
            timer = Time.time + rate;
            eaten--;

            if (eaten <= 0)
            {
				eaten = 0;
            }
        }
    }

    public void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "food" && eaten <= maxFood && Input.GetKeyDown(KeyCode.X)) {
            if ((maxFood - eaten) <= amountOfFood)
            {
                eaten = maxFood;
            }
            else
            {
                eaten += amountOfFood;
            }
            eating = true;
            //audio_pickup.isEating = true;
            Destroy (other.gameObject);
		}

	}


}
