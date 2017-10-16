using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHive : MonoBehaviour {
	public GameObject Hives;
	GameObject Player;
	food Pfood;
	public float usedFood = 0, y = 0.0f;
	public float timeBetween = 3;
	float timer = 0;

	// Use this for initialization
	void Start () {
		if (!Player)
		{
			Player = GameObject.FindGameObjectWithTag("Player");
			Pfood = Player.GetComponent<food>();
		}
	}

	// Update is called once per frame
	void Update() {
		if (!Player)
		{
			Player = GameObject.FindGameObjectWithTag("Player");
			Pfood = Player.GetComponent<food>();
		}


		if (Input.GetKey(KeyCode.F))
		{


			if (usedFood == 0)
			{


				usedFood = 10;
				Pfood.eaten -= 10;
			}
			if (usedFood == 10)
			{
				if (timer < timeBetween)
				{
					timer += 1 * Time.deltaTime;
					return;
				}

				usedFood = 20;
				Pfood.eaten -= 10;
				//**************//
				timer = 0;

			}
			if (usedFood == 20)
			{
				
					SpawnHive();
					usedFood = 0;
			}
		}
		else {
			if (usedFood != 0)
			{
				Pfood.eaten += usedFood;
				usedFood = 0;
			}
		}
	}
	void SpawnHive() {
		y = Player.transform.position.y - 3;
		Instantiate(Hives, new Vector3(Player.transform.position.x, y, 5), Quaternion.identity);
	}
}
