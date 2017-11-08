using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerWhenActivated : MonoBehaviour {
    public GameObject Spawn;
    Transform rot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(Spawn, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(0,90,0));
        this.gameObject.SetActive(false);
	}
    
}
