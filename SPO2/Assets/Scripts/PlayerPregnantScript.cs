﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPregnantScript : MonoBehaviour {
    public bool pregnant = false;
    public bool atDen = false;
    public GameObject partner;
    GameObject hive;
    public GameObject Cub;
    bool canBecomePregnant = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (pregnant && atDen && Input.GetKeyDown(KeyCode.Z))
        {
            pregnant = false;
            Instantiate(Cub, new Vector3(hive.transform.position.x, hive.transform.position.y, 0), Quaternion.identity);
        }
        if (canBecomePregnant && Input.GetKeyDown(KeyCode.Z))
        {
            pregnant = true;
            GameObject.FindGameObjectWithTag("Mate").transform.GetChild(1).gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Mate").transform.GetChild(1).gameObject, 3f);
        }


        if (partner == null)
        {
            partner = GameObject.Find("Partner");
        }

        if (pregnant == true)
        {
            GameObject.FindGameObjectWithTag("Hive").transform.GetChild(2).gameObject.SetActive(true);
        }
        
        else GameObject.FindGameObjectWithTag("Hive").transform.GetChild(2).gameObject.SetActive(false);
        

	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hive")
        {
            hive = other.gameObject;
            atDen = true;
        }
        if (other.gameObject == partner)
        {
            if (GameObject.FindWithTag("Cub") == null && GameObject.Find("BabiCub") == null)
            {
                canBecomePregnant = true;
                //pregnant = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hive")
        {
            atDen = false;
        }
        if (other.gameObject == partner)
        {
            canBecomePregnant = false;
        }
    }
}
