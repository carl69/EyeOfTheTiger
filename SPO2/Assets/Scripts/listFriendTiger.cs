using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class listFriendTiger : MonoBehaviour
{

	private Rigidbody rb;
	public float velocity = 5, distance2 = 4, distance3 = 5 ;
	bool escapeRight = false, escapeLeft = false;
	GameObject tigre;
	public float distance = 10;
	public GameObject[] players;

	UnityEngine.AI.NavMeshAgent enemigo;

	void Start()
	{

		rb = GetComponent<Rigidbody>();
		tigre = GameObject.Find("Player");


	}

	void Update(){
		if (escapeRight && (transform.position.x > tigre.transform.position.x)){
			players = GameObject.FindGameObjectsWithTag ("Player");
			if (+transform.position.x - tigre.transform.position.x >= distance2) {
				transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, velocity * Time.deltaTime);
			}
		}
		if (escapeLeft && (transform.position.x < tigre.transform.position.x)) {
			players = GameObject.FindGameObjectsWithTag("Player");
			if (-transform.position.x + tigre.transform.position.x >= distance3) {
				transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, velocity * Time.deltaTime);
				print (-transform.position.x + tigre.transform.position.x);
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