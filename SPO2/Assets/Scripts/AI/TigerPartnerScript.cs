using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPartnerScript : MonoBehaviour {
    public GameObject Cub;
    private bool birth = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (birth == false)
            {
                birth = true;
                Cub.SetActive(true);
            }
        }
    }
}
