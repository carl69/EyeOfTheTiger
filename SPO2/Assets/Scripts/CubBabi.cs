using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubBabi : MonoBehaviour {
    public int AmountOfFoodNeededToAgeUp;
    public int CurFood;
    public int Level = 1;
    private bool InHive;
    public float PickUpDistance;
    private Transform Hive;
    private GameObject Carry;
    private GameObject Player;
    private bool canPutInHive = false;
    private bool carrying = false;
    float dist;
    // Use this for initialization
    void Start () {
        if (!Player)
        {
            Player = GameObject.Find("Player");
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (CurFood >= AmountOfFoodNeededToAgeUp)
        {
            CurFood = 0;
            Level++;

        }



        if (!Player)
        {
            Player = GameObject.Find("Player");
        }

            if (Input.GetKeyDown(KeyCode.E) && dist < PickUpDistance && carrying == false)
            {
                carrying = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && carrying == true)
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
        }
	}


    void HiveMode()
    {
        if (Level == 1)
        {
            this.transform.position = new Vector2(Hive.position.x, Hive.position.y);
        }
        carrying = false;

    }
    void CarryMode()
    {
        if (!Carry)
        {
            Carry = GameObject.Find("CubHoldingPosition");
        }

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
