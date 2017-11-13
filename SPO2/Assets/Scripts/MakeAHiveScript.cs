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
        if (PlayerPrefs.GetInt("Den") == 0)
        {
            int getplayerprefs = PlayerPrefs.GetInt("Den");
            PlayerPrefs.SetInt("Den", getplayerprefs + 1);
            //print(getplayerprefs + "  " + PlayerPrefs.GetInt("Den"));
        }


        Destroy(destroyThisOne);
        startThisScript.enabled = true;
        Destroy(this.gameObject);
	}
}
