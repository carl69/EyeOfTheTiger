using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {

    public GameObject TigerPrefab;
    public GameObject textBox;
    public bool deathTextShown = false;
    food Food;
    PlayerWater playerWater;
	// Use this for initialization
	void Start () {
        if (this.gameObject.name != "Player")
        {
            this.gameObject.name = "Player";
        }



        Food = this.gameObject.GetComponent<food>();
        playerWater = this.gameObject.GetComponent<PlayerWater>();
        textBox = GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("1");
            DestroyPlayer();
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                Debug.Log("Cub found!");
                CreateNewPlayer();
                DestroyCub();
                if (deathTextShown == false)
                {
                    FirstDeath();
                }
            } 
            else
            {
                GameOver();
            }
        }
       
        if(collision.gameObject.tag == "WallofDeath")
        {
            DestroyPlayer();
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                CreateNewPlayer();
                DestroyCub();
                if (deathTextShown == false)
                {
                    FirstDeath();
                }
            }
            else
            {
                GameOver();
            }
        }
        if(collision.gameObject.tag == "Bullet")
        {
            DestroyPlayer();
            if (GameObject.FindGameObjectWithTag("Cub") == true)
            {
                CreateNewPlayer();
                DestroyCub();
                if (deathTextShown == false)
                {
                    FirstDeath();
                }
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
                if (deathTextShown == false)
                {
                    FirstDeath();
                }
            }
            else {
                GameOver();
            }
        }
	}


    void FirstDeath() {
        textBox.SetActive(true);
        textBox.transform.GetChild(1).GetComponent<Text>().text = "When you die you will continue playing as your cub, if you have one...";
        deathTextShown = true;
        Time.timeScale = 0;
    }
    void DestroyPlayer() {
        //gameObject.SetActive(false);
        Destroy(this.gameObject);
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
        textBox.transform.GetChild(1).GetComponent<Text>().text = "You died and have no cubs to keep playing.";
    }
}
