﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPartnerSpawner : MonoBehaviour {
    public GameObject Partner;
    public GameObject Player;
    public food Pfood;
    public float usedFood = 0;
    public float timeBetween = 3;
    float timer = 0;

	// Use this for initialization
	void Start () {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Pfood = Player.GetComponent<food>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Pfood = Player.GetComponent<food>();
        }


        if (Input.GetKey(KeyCode.F) && !GameObject.FindGameObjectWithTag("Partner"))
        {


            if (usedFood == 0)
            {


                usedFood = 20;
                Pfood.eaten -= 20;
            }
            if (usedFood == 20)
            {
                if (timer < timeBetween)
                {
                    timer += 1 * Time.deltaTime;
                    return;
                }
                
                    usedFood = 40;
                    Pfood.eaten -= 20;
                    //**************//
                    timer = 0;
                
            }
            if (usedFood == 40)
            {
                if (!GameObject.FindGameObjectWithTag("Partner") && !GameObject.FindGameObjectWithTag("Cub"))
                {
                    SpawnPartner();
                    usedFood = 0;
                }
                else
                {
                    Pfood.eaten += usedFood;
                    usedFood = 0;
                }
            }
        }
        else {
            if (usedFood != 0)
            {
                Pfood.eaten += usedFood;
                usedFood = 0;
            }
        }
    }
    void SpawnPartner() {
        int SpawnPoint = Random.Range(0, transform.childCount);
        GameObject partnerSpawner = this.gameObject.transform.GetChild(SpawnPoint).gameObject;
        Instantiate(Partner, new Vector3(partnerSpawner.transform.position.x, partnerSpawner.transform.position.y, 0), Quaternion.identity);
    }
}
