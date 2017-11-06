using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBankReset : MonoBehaviour {
    public GameObject FoodBank;

    public PlayerPayingFoodToThisObject foodbankPay;
    public int food;

    public GameObject cubmang;
    public CubSceneManager cubmangScript;
	// Use this for initialization
	void Start () {

        //foodbankPay = FoodBank.GetComponent<PlayerPayingFoodToThisObject>();
        
	}
    private void OnEnable()
    {
        cubmang = GameObject.FindGameObjectWithTag("SceneManager");
        cubmangScript = cubmang.GetComponent<CubSceneManager>();
    }
    // Update is called once per frame
    void Update () {

        cubmangScript.StoredFood += 1;

        foodbankPay.Done = false;
        foodbankPay.enabled = true;
        this.gameObject.SetActive(false);
    }
}
