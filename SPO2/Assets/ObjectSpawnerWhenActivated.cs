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
        Instantiate(Spawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.Euler(0,90,0));
        this.gameObject.SetActive(false);
	}
    
}
