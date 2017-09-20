using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour {
    public int maxFood = 100;
	public int eaten = 50;
    public int amountOfFood = 10;
    // food loss rate
    public float rate;
    private float timer;

    private void Update()
    {

        if (timer < Time.time)
        {
            timer = Time.time + rate;
            eaten--;

            if (eaten <= 0)
            {
                SceneManager.LoadScene("Prototype");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "food" && eaten <= maxFood) {
            if ((maxFood - eaten) <= amountOfFood)
            {
                eaten = maxFood;
            }
            else
            {
                eaten += amountOfFood;
            }
            Destroy (other.gameObject);
		}

	}

	void OnGUI (){
		GUILayout.Label ("food =" + eaten);
	}
}
