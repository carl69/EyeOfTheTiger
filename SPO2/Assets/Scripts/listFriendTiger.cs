using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class listFriendTiger : MonoBehaviour
{

	private Rigidbody rb;
	public float velocity = 5, distance2 = 10, distance3 = 11, velocity2 = -5 ;
	bool escapeRight = false, escapeLeft = false;
	GameObject tigre, POS;
	public float distance = 20;
	public GameObject[] players;

	void Start()
	{

		rb = GetComponent<Rigidbody>();
		tigre = GameObject.Find("Player");


	}

	void Update(){

		if (escapeRight && (transform.position.x > tigre.transform.position.x)){
			players = GameObject.FindGameObjectsWithTag ("Player");
			if (+transform.position.x - tigre.transform.position.x >= distance2) {
				rb.velocity = new Vector2 (velocity2, rb.velocity.y);
			}
		}
		if (escapeLeft && (transform.position.x < tigre.transform.position.x)) {
			players = GameObject.FindGameObjectsWithTag("Player");
			if (-transform.position.x + tigre.transform.position.x >= distance3) {
				rb.velocity = new Vector2 (velocity, rb.velocity.y);
			}
		}
		checkDistancia ();
	}

	void checkDistancia(){
		if (!escapeRight && (transform.position.x < 0 && +transform.position.x - tigre.transform.position.x <= distance) || (transform.position.x > 0 && transform.position.x - tigre.transform.position.x <= distance)) {
			escapeRight = true;
		}
		if (!escapeLeft && (transform.position.x < 0 && -transform.position.x + tigre.transform.position.x <= distance) || (transform.position.x > 0 && -transform.position.x + tigre.transform.position.x <= distance)) {
			escapeLeft = true;
		}
	}

}