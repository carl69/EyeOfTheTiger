﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWater : MonoBehaviour {

    public float MaxThirst;
    public float CurThirst;
    float WaterProsent;
    PlayerWater Water;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        Water = player.GetComponent<PlayerWater>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            Water = player.GetComponent<PlayerWater>();
            player = GameObject.FindWithTag("Player");
            Debug.Log("FUCK");
        }



        MaxThirst = Water.MaxWater;
        CurThirst = Water.drink;



        WaterProsent = CurThirst / MaxThirst;
        int WaterProsentint = Mathf.RoundToInt(WaterProsent * 10);
        if (WaterProsentint <= 10)
        {
            for (int i = 0; i < WaterProsentint; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 9; WaterProsentint < i + 1; i--)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        //transform.localScale = new Vector3(CurThirst / MaxThirst, 1, 0); 
    }
}
