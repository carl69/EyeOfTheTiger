using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAHiveScript : MonoBehaviour {
    public PlayerPayingFoodToThisObject startThisScript;
    public GameObject scriptHolder;
    public GameObject destroyThisOne;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(destroyThisOne);
        startThisScript.enabled = true;
        Destroy(this.gameObject);
	}
}
