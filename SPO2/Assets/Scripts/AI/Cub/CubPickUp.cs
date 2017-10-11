using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubPickUp : MonoBehaviour {
    public bool canPickUp = false;
    bool pickedUp = false;
    bool inHive = false;
    bool canHive = false;
    public float pickUpDist;
    public Transform holdingPosision;
    private Transform hiveLocal;

    GameObject curHive;
    public GameObject curplayer;
    MamaTigerMovement cubMovement;

    public float dist;
    // Use this for initialization
    void Start () {
        cubMovement = this.gameObject.GetComponent<MamaTigerMovement>();
        curplayer = GameObject.Find("CubHoldingPosition");
        holdingPosision = curplayer.transform;
	}

    // Update is called once per frame
    void Update() {
        dist = Vector3.Distance(holdingPosision.position, transform.position);
        if (dist < pickUpDist)
        {
            Debug.Log("In  Pick up range");
            canPickUp = true;
        }
        else
        {
            Debug.Log("Out of pick up range");
            canPickUp = false;
        }

            if (pickedUp)
        {
            transform.position = holdingPosision.position;
            cubMovement.enabled = false;
        }
        if (inHive)
        {
            Debug.Log("Hive");
            HiveMode();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!pickedUp && canPickUp)
            {
                Debug.Log("Pick up");
                pickedUp = true;
                inHive = false;
            }
            else if (pickedUp && canHive)
            {
                Debug.Log("Put In The Hive");
                inHive = true;
                pickedUp = false;
            }
            else if (pickedUp)
            {
                Debug.Log("Put down");
                cubMovement.enabled = true;
                pickedUp = false;
            }
        }

	}
    void HiveMode() {
        hiveLocal = curHive.transform;
        transform.position = new Vector3(hiveLocal.position.x, hiveLocal.position.y, 0);
        cubMovement.enabled = false;
    }
    private void OnTriggerEnter(Collider c)
    {
        //if (c.tag =="Player")
        //{
        //    Debug.Log("In  Pick up range");
        //    canPickUp = true;
        //}
        if (c.tag == "Hive")
        {
            Debug.Log("In Hive range");
            curHive = c.gameObject;
            canHive = true;
        }
    }
    private void OnTriggerExit(Collider c)
    {
        //if (c.tag == "Player")
        //{
        //    Debug.Log("Out of pick up range");
        //    canPickUp = false;
        //}
        if (c.tag == "Hive")
        {
            Debug.Log("Out of Hive range");
            canHive = false;
        }
        
    }
}
