using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubBabi : MonoBehaviour {
    public int AmountOfFoodNeededToAgeUp;
    public int CurFood;
    public int Level = 1;
     bool InHive;
    public float PickUpDistance;
     Transform Hive;
     public GameObject Carry;
     GameObject Player;
    public GameObject Cub;
     bool canPutInHive = false;
     bool carrying = false;
     float dist;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        if (this.gameObject.name != "BabiCub") 
        {
            this.gameObject.name = "BabiCub";
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!Player)
        {
            Player = GameObject.Find("Player");
            if (!Carry)
            {
                Carry = GameObject.Find("CubHoldingPosition");
            }
        }

        if (Level == 2)
        {
            Instantiate(Cub, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (CurFood >= AmountOfFoodNeededToAgeUp)
        {
            CurFood = 0;
            Level++;

        }



        if (!Player)
        {
            Player = GameObject.Find("Player");
        }

            if (Input.GetKeyDown(KeyCode.Z) && dist < PickUpDistance && carrying == false)
            {
                carrying = true;
            }
            else if (Input.GetKeyDown(KeyCode.Z) && carrying == true)
            {
                carrying = false;
            }
            if (carrying)
            {
                CarryMode();
            }
            else
            {
                dist = Vector3.Distance(Player.transform.position, transform.position);
            }
        
        if (canPutInHive && carrying == false)
        {
            HiveMode();
            if (rb.useGravity == true)
            {
                rb.useGravity = false;
            }
        }
        else if (rb.useGravity == false)
        {
            rb.useGravity = true;
        }
	}


    void HiveMode()
    {
        if (Level == 1)
        {
            this.transform.position = new Vector3(Hive.position.x, Hive.position.y,0);
        }
        

    }
    void CarryMode()
    {
        

        this.transform.position = Carry.transform.position;
    }
    void OnTheGround()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hive")
        {
            canPutInHive = true;
            Hive = other.transform;
        }
        if (other.tag == "food")
        {
            CurFood++;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hive")
        {
            canPutInHive = false;
        }
    }
}
