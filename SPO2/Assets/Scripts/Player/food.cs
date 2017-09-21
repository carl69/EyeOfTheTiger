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

	public GameObject button;

    private void Update()
    {

        if (timer < Time.time)
        {
            timer = Time.time + rate;
            eaten--;

            if (eaten <= 0)
            {
				button.SetActive (true);
				eaten = 0;
               // SceneManager.LoadScene("Prototype");
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.tag == "food" && eaten <= maxFood && Input.GetKeyDown(KeyCode.Space)) {
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


}
