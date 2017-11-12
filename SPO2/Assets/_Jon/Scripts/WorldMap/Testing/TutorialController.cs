using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public GameObject Instructions01;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Days") == 1)
        {
            Instructions01.SetActive(true);
        }
	}
}
