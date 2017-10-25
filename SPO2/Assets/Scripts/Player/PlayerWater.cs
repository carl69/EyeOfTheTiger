using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWater : MonoBehaviour
{
    [HideInInspector]
    public bool drinking = false;
    public float drink = 50;
    [HideInInspector]
    public float MaxWater = 100;
    // how fast you lose water
    private float rate = 2;
    private float timer;
   // public GameObject button;
    //int counter = 0;
    private float lossAmount = 1;
    Audio_pickup audio_pickup;
    public float drinkAmount;
    [HideInInspector]
    public bool drinkAudio = false;

    playerStats PlayStats;
    private void Start()
    {
        PlayStats = this.gameObject.GetComponent<playerStats>();
        MaxWater = PlayStats.maxWater;
        drink = PlayStats.startWater;
        rate = PlayStats.waterLossRate;
        lossAmount = PlayStats.waterLossAmount;
        //drinkAmount = PlayStats.waterPickUp;
        


        //audio_pickup = GameObject.Find("PickUps").GetComponent<Audio_pickup>();
    }

    void Update()
    {
        if (drinkAudio == true)
        {
            drinkAudio = false;
        }

        if (drinking == true && Input.GetKey(KeyCode.E))
        {
            if (drink < MaxWater)
            {
                drinkAudio = true;              
                drink += drinkAmount;
            }
        }
        else if (timer < Time.time)
        {
            timer = Time.time + rate;
            drink -= lossAmount;
            if (drink <= 0)
            {
               // button.SetActive(true);
                drink = 0;
                //counter = 30;
                //gameObject.GetComponent<Rigidbody>().gravityScale = 0;


            }

        }
        //if (counter > 0)
        //{
        //    counter--;
        //    transform.RotateAround(transform.position, new Vector3(1, 0, 0), 3);
            //gameObject.GetComponent<Rigidbody>().gravityScale = 0;
        //}


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            drinking = true;
        }


    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "water")
            drinking = false;
    }

}

