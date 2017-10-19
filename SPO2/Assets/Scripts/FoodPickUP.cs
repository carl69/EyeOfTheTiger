using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickUP : MonoBehaviour {
    GameObject Player;
    public GameObject CubHoldingPosition;
    float dist;
    public float pickUpRange;
    bool carrying = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!Player || !CubHoldingPosition)
        {
            Player = GameObject.Find("Player");
            CubHoldingPosition = GameObject.Find("CubHoldingPosition");
        }


        dist = Vector2.Distance(Player.transform.position, transform.position);

        if (dist < pickUpRange && Input.GetKeyDown(KeyCode.Z) && carrying == false)
        {
            carrying = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            carrying = false;
        }
        if (carrying)
        {
            transform.position = new Vector2(CubHoldingPosition.transform.position.x, CubHoldingPosition.transform.position.y);
                //CubHoldingPosition.transform.position;
        }

    }

    
}
