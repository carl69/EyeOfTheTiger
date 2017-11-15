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
    public Canvas canvasSpawn;
    public Canvas PlayerUi;
    public GameObject audioController;
    public Button Resume;

    private AudioSource playerDeath;

	// Use this for initialization
	void Start () {
        if (this.gameObject.name != "Player")
        {
            this.gameObject.name = "Player";
        }


        playerDeath = GameObject.FindGameObjectWithTag("AudioController").transform.GetChild(1).transform.GetChild(1).transform.GetChild(2).GetComponent<AudioSource>();
        Debug.Log(playerDeath);


        if (GameObject.FindGameObjectWithTag("AudioController") == null)
        {
            Instantiate(audioController);
        }


        Food = this.gameObject.GetComponent<food>();
        playerWater = this.gameObject.GetComponent<PlayerWater>();
        if (GameObject.FindGameObjectWithTag("TextPrompts") == null)
        {
            //Instantiate(canvasSpawn);
        }
       
        if (GameObject.FindGameObjectWithTag("PlayerUI") == null)
        {
            //Instantiate(PlayerUi);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("Player entered trap!");
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

        //if (collision.gameobject.tag == "wallofdeath")
        //{
        //    destroyplayer();
        //    if (gameobject.findgameobjectwithtag("cub") == true)
        //    {
        //        createnewplayer();
        //        destroycub();
        //        if (deathtextshown == false)
        //        {
        //            firstdeath();
        //        }
        //    }
        //    else
        //    {
        //        gameover();
        //    }
        //}
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
        //if (food.eaten <= 0 || playerwater.drink <= 0)
        //{
        //    if (gameobject.findgameobjectwithtag("cub") == true)
        //    {
        //        destroyplayer();
        //        createnewplayer();
        //        destroycub();
        //        if (deathtextshown == false)
        //        {
        //            firstdeath();
        //        }
        //    }
        //    else
        //    {
        //        gameover();
        //    }
        //}
    }


    void FirstDeath() {
        textBox.SetActive(true);
        textBox.transform.GetChild(1).GetComponent<Text>().text = "When you die you will continue playing as your cub, if you have one...";
        Resume.interactable = false;
        deathTextShown = true;
        Time.timeScale = 0;
    }
    void DestroyPlayer() {
        //gameObject.SetActive(false);
        playerDeath.Play();
        Debug.Log("Death audio playing");
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
        textBox.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "You died and have no cubs to keep playing.";
        Resume.interactable = false;
    }
}
