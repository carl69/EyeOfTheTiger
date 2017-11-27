using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDayReport : MonoBehaviour {
	CarlsPlayerprefsStalkerScript datas;
	//public int NumberFoodInPocket, NumberFoodInFridge, FoodInPocketAndFridge, FinalFoodInReport, actualizarDatas, RestInFridgeToZero, RestInFridge, RestInPocket;
	public float NumberFoodInPocket, NumberFoodInFridge, FoodInPocketAndFridge, FinalFoodInReport, actualizarDatas, RestInFridgeToZero, RestInFridge, RestInPocket;
	public int subtractedFood = 5;
	// Use this for initialization
	void Start () {
		datas = GetComponent<CarlsPlayerprefsStalkerScript>();
	}
		// Update is called once per frame
	void Update () {
		NumberFoodInPocket = datas.Food / 10;
		NumberFoodInFridge = datas.StoredFood;
		print ("yep");
		if (NumberFoodInFridge > 0 && NumberFoodInFridge <= subtractedFood) {
			print ("hola");
			RestInFridgeToZero = subtractedFood - NumberFoodInFridge;
			RestInPocket = NumberFoodInPocket - RestInFridgeToZero;
			datas.StoredFood = 0;
			datas.Food = RestInPocket * 10;

		} else if (NumberFoodInFridge > subtractedFood) {
			print ("hola2");
			RestInFridge = NumberFoodInFridge - subtractedFood;
			datas.StoredFood = (int) RestInFridge;

		} else if (NumberFoodInFridge == 0) {
			print ("hola3");
			RestInPocket = NumberFoodInPocket - subtractedFood;
			print (datas.Food);
			datas.Food = RestInPocket * 10;
			print (datas.Food);
		}
 
	}
}
