using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBankReset : MonoBehaviour {
    public GameObject FoodBank;

    public GameObject SpriteToUpdate;
    public Sprite smallPile;
    public Sprite mediumPile;
    public Sprite bigPile;

    public PlayerPayingFoodToThisObject foodbankPay;
    

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

    private void LateUpdate()
    {
        if (PlayerPrefs.GetInt("StoredFood") >= 1 && PlayerPrefs.GetInt("StoredFood") <= 9)
        {
            SpriteToUpdate.GetComponent<SpriteRenderer>().sprite = smallPile;
        }
        if (PlayerPrefs.GetInt("StoredFood") >= 10 && PlayerPrefs.GetInt("StoredFood") <= 14)
        {
            SpriteToUpdate.GetComponent<SpriteRenderer>().sprite = mediumPile;
        }
        if (PlayerPrefs.GetInt("StoredFood") >= 15 && PlayerPrefs.GetInt("StoredFood") <= 19)
        {
            SpriteToUpdate.GetComponent<SpriteRenderer>().sprite = bigPile;
        }
    }

    // Update is called once per frame
    void Update () {

    cubmangScript.StoredFood += 1;

       

        foodbankPay.Done = false;
        foodbankPay.enabled = true;
        this.gameObject.SetActive(false);
    }
}
