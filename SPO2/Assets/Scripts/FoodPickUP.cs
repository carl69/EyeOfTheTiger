using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickUP : MonoBehaviour {
    GameObject Player;
    GameObject CubHoldingPosition;
    float dist;
    public float pickUpRange;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!Player)
        {
            Player = GameObject.Find("Player");
            CubHoldingPosition = GameObject.Find("CubHoldingPosition");
        }
        dist = Vector2.Distance(Player.transform.position, transform.position);

        if (dist < pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            
        }

    }

    
}
