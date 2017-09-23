using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWater : MonoBehaviour
{
    public bool drinking = false;
    public float drink = 50;
    public float MaxWater = 100;
    // how fast you lose water
    public float rate = 2;
    private float timer;
    public GameObject button;
    int counter = 0;
    public float lossAmount = 1;
    Audio_pickup audio_pickup;

    public bool drinkAudio = false;

    playerStats PlayStats;
    private void Start()
    {
        PlayStats = this.gameObject.GetComponent<playerStats>();
        MaxWater = PlayStats.maxWater;


        //audio_pickup = GameObject.Find("PickUps").GetComponent<Audio_pickup>();
    }

    void Update()
    {
        if (drinkAudio == true)
        {
            drinkAudio = false;
        }

        if (drinking == true && Input.GetKey(KeyCode.Space))
        {
            if (drink < MaxWater)
            {
                drinkAudio = true;
                drink++;
            }
        }
        else if (timer < Time.time)
        {
            timer = Time.time + rate;
            drink -= lossAmount;
            if (drink <= 0)
            {
                button.SetActive(true);
                drink = 0;
                counter = 30;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;


            }

        }
        if (counter > 0)
        {
            counter--;
            transform.RotateAround(transform.position, new Vector3(1, 0, 0), 3);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "water")
        {
            drinking = true;
        }


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "water")
            drinking = false;
    }

}

