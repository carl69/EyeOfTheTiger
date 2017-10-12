using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePoacher : MonoBehaviour {
	bool campa = false;
	public GameObject poach;
	//public GameObject[] cazadores;
	public float velocity = 5 ;
	private Rigidbody rb;
	public float counter = 0.0f;

	//public GameObject respawnPrefab;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		poach = GameObject.FindGameObjectWithTag ("Poachers");
		/*if(cazadores == null)
			cazadores = GameObject.FindGameObjectsWithTag ("Enemie");*/
	}
	// Update is called once per frame
	void Update () {
		if (campa) {
			poach.transform.position = Vector2.MoveTowards (poach.transform.position,transform.position , -1 * velocity * Time.deltaTime);
			counter++;
			if (counter >= 270)
				Destroy (poach.gameObject);
			/*foreach (GameObject Enemie in cazadores)
			{
				print ("entro for");
				Instantiate(respawnPrefab, Enemie.transform.position, Enemie.transform.rotation);
				respawnPrefab.transform.position = Vector2.MoveTowards (respawnPrefab.transform.position, transform.position, -1 * velocity * Time.deltaTime);
			}*/
		}
	}




	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Poacher_camp") {
			campa = true;
		}
	}
}
