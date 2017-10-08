using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class listFriendTiger : MonoBehaviour
{

	private Rigidbody rb;
	public float velocity = 5, distance2 = 10, distance3 = 11, velocity2 = -5 ;
	bool escapeRight = false, escapeLeft = false, unavez = false ;
	GameObject tigre;
	public float distance = 20, mayor0 = 0;
	public GameObject[] players;
	int counter = 0;

	void Start()
	{

		rb = GetComponent<Rigidbody>();
		tigre = GameObject.Find("Cub");
		players =new GameObject[10];


	}

	void Update(){
		if (escapeRight && (transform.position.x > tigre.transform.position.x)){
			if (!unavez) {
				players [counter] = tigre;
				counter++;
				unavez = true;
			}
			if (+transform.position.x - tigre.transform.position.x >= distance2) {
				rb.velocity = new Vector2 (velocity2, rb.velocity.y);
			}
		}
		if (escapeLeft && (transform.position.x < tigre.transform.position.x)) {
			if (!unavez) {
				players [counter] = tigre;
				counter++;
				unavez = true;
			}
			if (-transform.position.x + tigre.transform.position.x >= distance3) {
				rb.velocity = new Vector2 (velocity, rb.velocity.y);
			}
		}
		checkDistancia ();
	}

	void checkDistancia(){
		//The part cemment is if the game is in negative part
		if (!escapeRight && /*(transform.position.x < 0 && +transform.position.x - tigre.transform.position.x <= distance) || */(transform.position.x > 0 &&  transform.position.x - tigre.transform.position.x <= distance  &&  transform.position.x - tigre.transform.position.x >= mayor0)){
			escapeRight = true;
		}
		if (!escapeLeft && /*(transform.position.x < 0 && -transform.position.x + tigre.transform.position.x <= distance) ||*/ (transform.position.x > 0 && -transform.position.x + tigre.transform.position.x <= distance && -transform.position.x + tigre.transform.position.x >= mayor0 )){
			escapeLeft = true;
		}
	}

}
	