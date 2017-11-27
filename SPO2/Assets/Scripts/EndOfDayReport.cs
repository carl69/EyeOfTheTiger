using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDayReport : MonoBehaviour {
	CarlsPlayerprefsStalkerScript datas;
	//public int NumberFoodInPocket, NumberFoodInFridge, FoodInPocketAndFridge, FinalFoodInReport, actualizarDatas, RestInFridgeToZero, RestInFridge, RestInPocket;
	public float NumberFoodInPocket, NumberFoodInFridge, FoodInPocketAndFridge, FinalFoodInReport, actualizarDatas, RestInPocketToZero, RestInFridge, RestInPocket;
	public int subtractedFood = 11;
	// Use this for initialization
	void Start () {
		datas = GetComponent<CarlsPlayerprefsStalkerScript>();
	}
		// Update is called once per frame
	public void Equation () {
		NumberFoodInPocket = datas.Food / 10;
		NumberFoodInFridge = datas.StoredFood;
		print ("yep");
		if (NumberFoodInPocket > 0 && NumberFoodInPocket <= subtractedFood) {
			print ("hola");
			RestInPocketToZero = subtractedFood - NumberFoodInPocket ;
			RestInFridge = NumberFoodInFridge - RestInPocketToZero;
			datas.StoredFood = (int) RestInFridge;
			datas.Food = 0;
			if(datas.StoredFood < 0){
				datas.StoredFood = 0;
			}

		} else if (NumberFoodInPocket > subtractedFood) {
			print ("hola2");
			RestInPocket = NumberFoodInPocket - subtractedFood;
			datas.Food = RestInPocket * 10;

		} else if (NumberFoodInPocket == 0) {
			print ("hola3");
			RestInFridge = NumberFoodInFridge - subtractedFood;
			print (datas.Food);
			datas.StoredFood = (int)RestInFridge;
			print (datas.StoredFood);
		}
		
 
	}
}
