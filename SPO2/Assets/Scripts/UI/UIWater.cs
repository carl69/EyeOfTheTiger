using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWater : MonoBehaviour {

    public float MaxThirst;
    public float CurThirst;

    PlayerWater Water;
	// Use this for initialization
	void Start () {
        Water = GameObject.Find("Player").GetComponent<PlayerWater>();
    }
	
	// Update is called once per frame
	void Update () {
        Water = GameObject.Find("Player").GetComponent<PlayerWater>();


        MaxThirst = Water.MaxWater;
        CurThirst = Water.drink;

        transform.localScale = new Vector3(CurThirst / MaxThirst, 1, 0); 
	}
}
