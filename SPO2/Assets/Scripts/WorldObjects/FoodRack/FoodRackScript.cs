using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRackScript : MonoBehaviour {
    public int amountOfFood;
    bool canTakeFood = false;
    food Food;
    GameObject player;

	public Sprite newsprite;


	//private SpriteRenderer spriteRenderer; 
	//public Sprite Empty_Food_Rack;
	//public bool changeSprite = false;




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
						PlayerPrefs.SetFloat("Food", Food.eaten);
                    }
                    else
                    {
                        Food.eaten += Food.amountOfFood;
						PlayerPrefs.SetFloat("Food", Food.eaten);

                    }

                    amountOfFood -= 1;








					if (amountOfFood == 0) {
						//changeSprite = true;
						//spriteRenderer.sprite = Empty_Food_Rack;
						transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = newsprite;
							
							//.GetComponent<SpriteRenderer>().Sprite = new Sprite(Empty_Food_Rack);
						print ("change sprite");

					}




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
