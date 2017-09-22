using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubLife : MonoBehaviour {
    public float maxHunger = 100f, curHunger = 100f, hungerGain, hungerdrain, maxThirst = 100f, curThirst = 100f,thirstGain,thirstdrain;
    private bool drink = false, eat = false;


    // Update is called once per frame
    void Update() {

        if (drink == false)
        {
            waterDrain();
        }
        else {
            drinking();
        }

        foodDrain();

        if (curHunger <= 0 || curThirst <= 0)
        {
            death();
        }
	}
    void foodDrain() {
        curHunger -= hungerdrain * Time.deltaTime;
    }
    void eating()
    {
        if (curHunger + hungerGain < maxHunger)
        {
            curHunger += hungerGain;
        }
        else {
            curHunger = maxHunger;
        }
    }
    void waterDrain() {
        curThirst -= thirstdrain * Time.deltaTime;
    }
    void drinking() {
        if (curThirst < maxThirst)
        {
            curThirst += thirstGain * Time.deltaTime;
        }
    }
    
    void death() {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "water")
        {
            drink = true;
        }
        if (other.tag == "food")
        {
            eating();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "water")
        {
            drink = false;
        }
    }
}
