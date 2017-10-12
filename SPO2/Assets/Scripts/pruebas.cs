using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebas : MonoBehaviour {
	bool campa = false;
	public GameObject cazadores;
	public float distance = 753;
	public float velocity = 5/*, pos = 0 */;
	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		cazadores = GameObject.FindGameObjectWithTag ("Player");
		//pos=-cazadores.transform.position.x + 27.7; 
	}
	// Update is called once per frame
	void Update () {
		if (cazadores.transform.position.x  > distance) {
			print ("entro");
			//transform.position = Vector2.MoveTowards (cazadores.transform.position,transform.position , velocity * Time.deltaTime);
			rb.velocity = new Vector2 (velocity, rb.velocity.y);
		}
	}
		
/*	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Poacher_camp") {
			campa = true;
		}
	}*/
}
