using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFromFoodBank : MonoBehaviour {
    public bool caneat = false;
    int fud;

    GameObject cubSceneManager;
    CubSceneManager script01;
    GameObject player;
    food script02;

	// Use this for initialization
	void Start () {
        cubSceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        script01 = cubSceneManager.GetComponent<CubSceneManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        script02 = player.GetComponent<food>();
	}
	
	// Update is called once per frame
	void Update () {
        if (caneat)
        {
            if (Input.GetKeyDown(KeyCode.E) && PlayerPrefs.GetInt("StoredFood") != 0 && script02.eaten != 100)
            {

                PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") + script02.amountOfFood);
                //script02.eaten += script02.amountOfFood;
                fud = script01.StoredFood;
                fud -= 1;
                script01.StoredFood = fud;
            }
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            caneat = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            caneat = false;
        }
    }
}
