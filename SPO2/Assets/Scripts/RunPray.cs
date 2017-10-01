using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RunPray : MonoBehaviour
{
	
	private Rigidbody rb;
	public float velocity = 5 ;
	bool huir = false;
	GameObject tigre;
	public float distance = 10;
	void Start()
	{
		
		rb = GetComponent<Rigidbody>();
		tigre = GameObject.Find("Player");

	}
	void Update(){

		if (huir) rb.velocity = new Vector2 (velocity, rb.velocity.y);

		checkDistancia ();

	}


	void FixedUpdate()
	{
		

	}

	void checkDistancia(){
		print (+transform.position.x - tigre.transform.position.x);
		if (!huir && +transform.position.x  -tigre.transform.position.x <= distance || (transform.position.x >0 &&  -transform.position.x + tigre.transform.position.x <= distance )) {
			huir = true;
		}


	}


}
