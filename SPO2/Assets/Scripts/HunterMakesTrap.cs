using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMakesTrap : MonoBehaviour {

    public bool UseThisScript = false;
    public Renderer ren;
    //public Collider BCol;
	// Use this for initialization
	void Start () {
        if (UseThisScript)
        {
            ren = GetComponent<Renderer>();
            ren.enabled = false;
            //BCol = GetComponent<BoxCollider>();
            //BCol.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemie")
        {
            ren.enabled = true;
            //BCol.enabled = true;
        }
    }

}
