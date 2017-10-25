using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubLevelUp01 : MonoBehaviour {
    public GameObject babicub;
    public GameObject NewCub;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(NewCub, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(babicub);


    }
}
