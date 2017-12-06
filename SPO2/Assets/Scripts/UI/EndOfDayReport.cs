using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfDayReport : MonoBehaviour {
	CarlsPlayerprefsStalkerScript datas;
	//public int NumberFoodInPocket, NumberFoodInFridge, FoodInPocketAndFridge, FinalFoodInReport, actualizarDatas, RestInFridgeToZero, RestInFridge, RestInPocket;
	public float NumberFoodInPocket, NumberFoodInFridge, FoodInPocketAndFridge, FinalFoodInReport, actualizarDatas, RestInPocketToZero, RestInFridge, RestInPocket;
	public int subtractedFood = 2;

    public 

	// Use this for initialization
	void Start () {
		datas = GetComponent<CarlsPlayerprefsStalkerScript>();
        if (SceneManager.GetActiveScene().name.Contains("Den") && PlayerPrefs.GetInt("Days") > 0)
        {
            Equation();
        }
        else if (PlayerPrefs.GetInt("Days") == 0)
        {
            GameObject.Find("EndOfDayReport").SetActive(false);
        }
	}
		// Update is called once per frame
	public void Equation () {

        NumberFoodInPocket = PlayerPrefs.GetFloat("Food") / 10;
		NumberFoodInFridge = PlayerPrefs.GetInt("StoredFood");

        GameObject.Find("EndOfDayReport").gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = NumberFoodInFridge.ToString();
        GameObject.Find("EndOfDayReport").gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = NumberFoodInPocket.ToString();
        GameObject.Find("EndOfDayReport").gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text = subtractedFood.ToString();


		if (NumberFoodInPocket > 0 && NumberFoodInPocket <= subtractedFood) {
			RestInPocketToZero = subtractedFood - NumberFoodInPocket ;
			RestInFridge = NumberFoodInFridge - RestInPocketToZero;
            PlayerPrefs.SetInt("StoredFood", (int)RestInFridge);
            //datas.StoredFood = (int) RestInFridge;
            PlayerPrefs.SetFloat("Food",0);
			//datas.Food = 0;
			if(PlayerPrefs.GetInt("StoredFood") < 0){
                PlayerPrefs.SetInt("StoredFood", 0);
				//datas.StoredFood = 0;
			}

            print("1");

		} else if (NumberFoodInPocket > subtractedFood) {

            print("2");


            RestInPocket = NumberFoodInPocket - subtractedFood;
            print(RestInPocket);
            PlayerPrefs.SetFloat("Food", RestInPocket * 10);
			//datas.Food = RestInPocket * 10;

		} else if (NumberFoodInPocket == 0) {

            print("3");


            RestInFridge = NumberFoodInFridge - subtractedFood;
            PlayerPrefs.SetInt("StoredFood", (int)RestInFridge);
			//datas.StoredFood = (int)RestInFridge;
		}
       
        GameObject.Find("EndOfDayReport").gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = (NumberFoodInPocket + NumberFoodInFridge - subtractedFood).ToString();


    }

}
