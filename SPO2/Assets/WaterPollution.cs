using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPollution : MonoBehaviour {
    public float StartingWater;
    public float DecayRate;
    public float CurWater;
    public bool startDecay = false;
    public GameObject wallOfDeath;
    private bool outdated = true;

    PlayerWater Water;
	void Start () {
        CurWater = StartingWater;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (startDecay == true && CurWater > 0)
        {
            CurWater -= DecayRate * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1 * CurWater, 1);
        }
        else if (outdated == true)
        {
            //Destroy(this);
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
            Debug.Log("God help us all");
            outdated = false;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Water = other.GetComponent<PlayerWater>();
            Water.drinkAmount = CurWater;
        }
    }
}
