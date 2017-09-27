using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHunger : MonoBehaviour {

    private float MaxHunger;
    private float CurHunger;

    food Food;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        Food = player.GetComponent<food>();
    }
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            Food = player.GetComponent<food>();
        }


        MaxHunger = Food.maxFood;
        CurHunger = Food.eaten;

        transform.localScale = new Vector3(CurHunger / MaxHunger, 1, 0); 
	}
}
