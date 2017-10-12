using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterGunAiming : MonoBehaviour {
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }
        transform.LookAt(Player.transform);
        //transform.rotation = Quaternion.LookRotation(transform.position - Player.transform.position);
    }
}
