using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubPickUp : MonoBehaviour {
    bool canPickUp = false;
    bool pickedUp = false;
    bool inHive = false;
    public Transform holdingPosision;
    private Transform hiveLocal;

    CubMovement cubMovement;
	// Use this for initialization
	void Start () {
        cubMovement = this.gameObject.GetComponent<CubMovement>();


	}

    // Update is called once per frame
    void Update() {


        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            pickedUp = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            pickedUp = false;
        }

        if (pickedUp)
        {
            transform.position = holdingPosision.position;
        }
        else {
        }

        if (inHive && !pickedUp)
        {
            transform.position = hiveLocal.position;
            cubMovement.enabled = false;
        }
	}
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag =="Player")
        {

            canPickUp = true;
        }
        if (c.tag == "Hive")
        {
            hiveLocal = c.transform;
            inHive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        cubMovement.enabled = true;
        if (c.tag == "Player")
        {
            canPickUp = false;
        }
        if (c.tag == "Hive")
        {
            inHive = false;
        }
    }
}
