using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour {
    public GameObject pray;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("");

            var gos = Instantiate(pray);
            gos.transform.parent = this.gameObject.transform;
            gos.transform.position = this.transform.position;
        }
	}
}
