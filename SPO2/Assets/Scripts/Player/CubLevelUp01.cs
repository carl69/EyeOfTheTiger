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
        int getplayerprefs = PlayerPrefs.GetInt("Cub");
        PlayerPrefs.SetInt("Cub", getplayerprefs + 1);
        print(getplayerprefs + "  " + PlayerPrefs.GetInt("Cub"));


        Instantiate(NewCub, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(babicub);


    }
}
