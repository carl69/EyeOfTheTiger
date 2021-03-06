﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPregnantScript : MonoBehaviour {
    public bool ZbuttonForHive = true;
    public bool pregnant = false;
    public bool atDen = false;
    public GameObject partner;
    public GameObject hive;
    public GameObject Cub;
    bool canBecomePregnant = false;

    public Sprite zButton;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject a = GameObject.FindGameObjectWithTag("Hive");

        if (pregnant == true)
        {
            if (ZbuttonForHive)
            {
                GameObject.FindGameObjectWithTag("Hive").transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = zButton;
                GameObject.FindGameObjectWithTag("Hive").transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = "Get a cub";
            }
            
        }
        //else
        //{
        //    GameObject.FindGameObjectWithTag("Hive").transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        //    GameObject.FindGameObjectWithTag("Hive").transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = null;
        //}

        if (pregnant && atDen && Input.GetKeyDown(KeyCode.Z))
        {
            pregnant = false;
            Instantiate(Cub, new Vector3(hive.transform.position.x, hive.transform.position.y, 0), Quaternion.identity);
        }
        if (canBecomePregnant && Input.GetKeyDown(KeyCode.Z))
        {
            pregnant = true;
            //GameObject.FindGameObjectWithTag("Partner").transform.GetChild(0).gameObject.SetActive(true);
            //Destroy(GameObject.FindGameObjectWithTag("Partner").transform.GetChild(1).gameObject, 3f);
            Destroy(partner, 1f);
        }


        if (partner == null)
        {
            partner = GameObject.FindGameObjectWithTag("Partner");
        }



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
