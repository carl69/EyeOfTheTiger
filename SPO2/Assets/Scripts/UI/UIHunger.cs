using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHunger : MonoBehaviour {

    private float MaxHunger;
    private float CurHunger;
    public float foodsProsent;
    food Food;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        Food = player.GetComponent<food>();
    }
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");  
            Food = player.GetComponent<food>();
        }


        MaxHunger = Food.maxFood;
        CurHunger = Food.eaten;

        //transform.localScale
        foodsProsent = CurHunger / MaxHunger;
        int foodProsentint = Mathf.RoundToInt(((foodsProsent) * 10));
        print(foodProsentint);
        print(foodsProsent);
        if (foodProsentint <= 10)
        {
            for (int i = 0; i < foodProsentint; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 9; foodProsentint < i+1 ; i--)
            {

                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        //{
        //    if (foodsProsent <= 0.9)
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            this.transform.GetChild(i).gameObject.SetActive(false);
        //        }
        //    }
            

        //}
        
        



	}
}
