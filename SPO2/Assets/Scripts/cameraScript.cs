using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public Transform Player;
    private Transform cameraposs;
    public float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player);
        //transform.position = Vector2.MoveTowards(transform.position, Player.position, speed);
	}
}
