using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWater : MonoBehaviour {

    private float MaxThirst;
    private float CurThirst;

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
            player = GameObject.FindWithTag("Player");
            Water = player.GetComponent<PlayerWater>();
        }


        MaxThirst = Water.MaxWater;
        CurThirst = Water.drink;

        transform.localScale = new Vector3(CurThirst / MaxThirst, 1, 0); 
	}
}
