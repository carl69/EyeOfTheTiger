using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public GameObject TigerPrefab;
    public GameObject textBox;
    public bool deathTextShown = false;

	// Use this for initialization
	void Start () {
        textBox = GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            gameObject.SetActive(false);
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                Debug.Log("Cub found!");
                Instantiate(TigerPrefab, GameObject.FindGameObjectWithTag("Cub").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Cub"));
                if (deathTextShown == false)
                {
                    textBox.SetActive(true);
                    textBox.transform.GetChild(8).gameObject.SetActive(true);
                    deathTextShown = true;
                    Time.timeScale = 0;
                }
            } 
            else
            {
                Debug.Log("No cub found!");
                Time.timeScale = 0;
                textBox.SetActive(true);
                textBox.transform.GetChild(9).gameObject.SetActive(true);
            }         
        }
       
        if(collision.gameObject.tag == "WallofDeath")
        {
            gameObject.SetActive(false);
            if(GameObject.FindGameObjectWithTag("Cub") == true)
            {
                Instantiate(TigerPrefab, GameObject.FindGameObjectWithTag("Cub").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Cub"));
                Destroy(GameObject.Find("CubUI"));

            }
            else
            {
                Debug.Log("No cub found!");
                Time.timeScale = 0;
                textBox.SetActive(true);
                textBox.transform.GetChild(9).gameObject.SetActive(true);
            }
        }
        if(collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                Instantiate(TigerPrefab, GameObject.FindGameObjectWithTag("Cub").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Cub"));
            }
            else
            {
                Debug.Log("No cub found!");
                Time.timeScale = 0;
                textBox.SetActive(true);
                textBox.transform.GetChild(9).gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
