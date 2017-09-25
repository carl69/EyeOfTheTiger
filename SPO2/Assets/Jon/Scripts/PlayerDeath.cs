using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public GameObject TigerPrefab;
    public GameObject textBox;
    public bool deathTextShown = false;
    food Food;
    PlayerWater playerWater;
	// Use this for initialization
	void Start () {
        //if (this.gameObject.name != "Player")
        //{
        //    this.gameObject.name = "Player";
        //}

        Food = this.gameObject.GetComponent<food>();
        playerWater = this.gameObject.GetComponent<PlayerWater>();
        textBox = GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("1");
            gameObject.SetActive(false);
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                Debug.Log("Cub found!");
                CreateNewPlayer();
                DestroyCub();
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
                GameOver();
            }
        }
       
        if(collision.gameObject.tag == "WallofDeath")
        {
            gameObject.SetActive(false);
            if(GameObject.FindGameObjectWithTag("Cub") == true)
            {
                CreateNewPlayer();
                DestroyCub();

            }
            else
            {
                GameOver();
            }
        }
        if(collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                CreateNewPlayer();
                DestroyCub();
            }
            else
            {
                GameOver();
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (Food.eaten <= 0 || playerWater.drink <= 0 )
        {
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                DestroyPlayer();
                CreateNewPlayer();
                DestroyCub();
            }
            else {
                GameOver();
            }
        }
	}



    void DestroyPlayer() {
        gameObject.SetActive(false);
    }
    void CreateNewPlayer()
    {
        Instantiate(TigerPrefab, GameObject.FindGameObjectWithTag("Cub").transform.position, Quaternion.identity);
    }
    void DestroyCub() {
        Destroy(GameObject.FindGameObjectWithTag("Cub"));
        Destroy(GameObject.Find("CubUI"));
    }
    void GameOver() {
        Debug.Log("No cub found!");
        Time.timeScale = 0;
        textBox.SetActive(true);
        textBox.transform.GetChild(9).gameObject.SetActive(true);
    }
}
