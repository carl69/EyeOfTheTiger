using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public GameObject TigerPrefab;
    public GameObject textBox;
    public bool deathTextShown = false;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
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
            if(GameObject.FindGameObjectWithTag("Cub").activeInHierarchy == true)
            {
                Instantiate(TigerPrefab, GameObject.FindGameObjectWithTag("Cub").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Cub"));
            }
            else
            {
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
