using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class food : MonoBehaviour {
	public int eaten = 50;
    public int amountOfFood = 10;
    // food loss rate
    public int rate;
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

		if (other.gameObject.tag == "food") {
			eaten += amountOfFood;
			Destroy (other.gameObject);
		}

	}

	void OnGUI (){
		GUILayout.Label ("food =" + eaten);
	}
}
