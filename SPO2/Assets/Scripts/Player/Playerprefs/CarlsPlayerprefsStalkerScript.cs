using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlsPlayerprefsStalkerScript : MonoBehaviour {
    public int Days;
    public int StoredFood;
    public int Cub;
    public int Den;
    public int Home;
    public bool Change = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Change == false)
        {
            Days = PlayerPrefs.GetInt("Days");
            StoredFood = PlayerPrefs.GetInt("StoredFood");
            Cub = PlayerPrefs.GetInt("Cub");
            Den = PlayerPrefs.GetInt("Den");
            Home = PlayerPrefs.GetInt("Home");
        }
        else
        {
            PlayerPrefs.SetInt("Days",Days);
            PlayerPrefs.SetInt("StoredFood", StoredFood);
            PlayerPrefs.SetInt("Cub", Cub);
            PlayerPrefs.SetInt("Den", Den);
            PlayerPrefs.SetInt("Home", Home);

        }



    }
}
