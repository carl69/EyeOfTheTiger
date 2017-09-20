using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHunger : MonoBehaviour {

    public float MaxHunger;
    public float CurHunger;

    food Food;
	// Use this for initialization
	void Start () {
        Food = GameObject.Find("Player").GetComponent<food>();
    }
	
	// Update is called once per frame
	void Update () {
        MaxHunger = Food.maxFood;
        CurHunger = Food.eaten;

        transform.localScale = new Vector3(CurHunger / MaxHunger, 1, 0); 
	}
}
