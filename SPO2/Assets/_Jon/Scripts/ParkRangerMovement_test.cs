using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRangerMovement_test : MonoBehaviour {

    public Transform cubPos;
    public bool cubSpotted = false;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Cub")
        //{
        //    cubPos = GameObject.FindGameObjectWithTag("Cub").transform;          
        //    cubSpotted = true;            
        //}
        //if(other.gameObject.tag == "Player")
        //{
        //    transform.GetChild(1).gameObject.SetActive(true);
        //}
        if(other.gameObject.tag == "Cub")
        {
            transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            Destroy(transform.GetChild(1).gameObject, 5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.GetChild(1).gameObject.SetActive(false);            
        }
    }

    // Update is called once per frame
    void Update () {
        if (cubSpotted == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cubPos.position, step);
        }

    }
}
