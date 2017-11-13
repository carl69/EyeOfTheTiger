using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRackScript : MonoBehaviour {
    public int amountOfFood;
    bool canTakeFood = false;
    food Food;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Food = player.GetComponent<food>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canTakeFood)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (amountOfFood >= 1)
                {
                    if (Food.maxFood - Food.eaten <= Food.amountOfFood)
                    {
                        Food.eaten = Food.maxFood;
                    }
                    else
                    {
                        Food.eaten += Food.amountOfFood;
                    }
                    
                    amountOfFood -= 1;
                }
                else
                {
                    print(this.gameObject.name + " is out of food :(");
                }
            }
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canTakeFood = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canTakeFood = false;
        }
    }
}
