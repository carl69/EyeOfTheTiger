﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour {
    [HideInInspector]
    public float maxFood = 100;
    //[HideInInspector]
    public bool eating = false;
    public float eaten = 100;
    [HideInInspector]
    public float amountOfFood = 10;
    // food loss rate
    private float rate;
    private float timer;
    //fix food pickup
	public bool canEatThis = false, canEatThese = false;
    private GameObject foodObject;

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

    private void FixedUpdate()
    {
        eaten = PlayerPrefs.GetFloat("Food");

        if (!foodObject)
        {
            canEatThis = false;
        }

        if (canEatThis)
        {
            if (/*foodObject.gameObject.tag == "food" && eaten <= maxFood && */Input.GetKeyDown(KeyCode.E))
            {
                

                if ((maxFood - eaten) <= amountOfFood)
                {
                    eaten = maxFood;
                }
                else
                {
                    eaten += amountOfFood;
                }
                eating = true;
                audio_pickup.isEating = true;
                PlayerPrefs.SetFloat("Food", eaten);
                Destroy(foodObject.gameObject);
            }
        }
		/*if (canEatThese)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{


				if ((maxFood - eaten) <= amountOfFood)
				{
					eaten = maxFood;
				}
				else
				{
					eaten += amountOfFood;
				}
				eating = true;
				audio_pickup.isEating = true;
				PlayerPrefs.SetFloat("Food", eaten);
			}
		}*/


        if (eating)
        {
            eating = false;
        }

    //    if (timer < Time.time)
    //    {
    //        timer = Time.time + rate;
    //        //eaten--;

    //        if (eaten <= 0)
    //        {
				//eaten = 0;
    //        }
    //    }
        //PlayerPrefs.SetFloat("Food", eaten);
    }

    public void OnTriggerEnter(Collider other){

        if (other.tag == "food")
        {
            canEatThis = true;
            foodObject = other.gameObject;
        }
		/*if (other.tag == "FoodBank")
		{
			canEatThese = true;
			foodObject = other.gameObject;
		}*/
	}

    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "food")
        {
            canEatThis = false;
        }
		/*if (other.tag == "FoodBank")
		{
			canEatThese = false;
		}*/

    }


}
