using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RunPrayMotherScene : MonoBehaviour
{
	
	private Rigidbody rb;
	public float velocity = 5 ;
	bool escapeRight = false, escapeLeft = false;
	GameObject tigre;
	public float distance = 10;
	void Start()
	{
		
		rb = GetComponent<Rigidbody>();
		tigre = GameObject.Find("MamaTiger");

	}

void Update(){

	if (escapeRight && (transform.position.x > tigre.transform.position.x))
		rb.velocity = new Vector2 (velocity, rb.velocity.y);
	else if (escapeLeft && (transform.position.x < tigre.transform.position.x)) {
		transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, -1 * velocity * Time.deltaTime);
	}
	checkDistancia ();
}

void checkDistancia(){
	if (!escapeRight && +transform.position.x  -tigre.transform.position.x <= distance || (transform.position.x >0 &&  -transform.position.x + tigre.transform.position.x <= distance ))
		escapeRight = true;
		
	else if (!escapeLeft && -transform.position.x  +tigre.transform.position.x <= distance || (transform.position.x >0 &&  +transform.position.x - tigre.transform.position.x <= distance ))
		escapeLeft = true;
}
}