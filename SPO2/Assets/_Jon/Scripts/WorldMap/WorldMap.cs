using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMap : MonoBehaviour
{

    public float speed;
    public GameObject selectedNode;

    public Sprite[] mapUpdates;

    public bool playerMoving = false;

    public GameObject currentHome;

    public Sprite HomeDen;
    public Sprite HomeText;

    public AudioClip MapUpdateClip;
    public bool mapUpdateClipHasPlayed = false;

    public bool playerStartPosUpdated = false;

    // Use this for initialization
    void Start()
    {
        mapUpdateClipHasPlayed = false;
        playerStartPosUpdated = false;
    }

    private void UpdateHome()
    {
        currentHome.GetComponent<SphereCollider>().enabled = false;
        currentHome.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = HomeDen;
        currentHome.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        currentHome.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        currentHome.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = HomeText;
       
    }

    //Function for moving player on world map
    private void MovePlayer()
    {
        if (playerMoving == true)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.MoveTowards(GameObject.FindGameObjectWithTag("Player").transform.position, selectedNode.transform.position, speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Home") == 1)
        {
            currentHome = GameObject.Find("Dens").transform.GetChild(1).gameObject;
            UpdateHome();
            if (playerStartPosUpdated == false)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = currentHome.transform.position;
                playerStartPosUpdated = true;
            }
        }
        if (PlayerPrefs.GetInt("Home") == 2)
        {
            currentHome = GameObject.Find("Dens").transform.GetChild(2).gameObject;
            UpdateHome();
            if (playerStartPosUpdated == false)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = currentHome.transform.position;
                playerStartPosUpdated = true;
            }
        }



        //Update map and nodes according to in-game days
        if (PlayerPrefs.GetInt("Days") >= 2)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[0];
            GameObject.Find("Nodes").transform.GetChild(1).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 3)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[1];
            GameObject.Find("Nodes").transform.GetChild(0).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 4)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[2];
            GameObject.Find("Dens").transform.GetChild(0).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 5)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[3];
            GameObject.Find("Nodes").transform.GetChild(3).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 6)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[4];
            GameObject.Find("Nodes").transform.GetChild(2).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 7)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[5];
            GameObject.Find("Nodes").transform.GetChild(4).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 8)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[6];
            GameObject.Find("Dens").transform.GetChild(1).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 9)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[7];
            GameObject.Find("Nodes").transform.GetChild(5).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }
        if (PlayerPrefs.GetInt("Days") >= 10)
        {
            GameObject.Find("Map").GetComponent<SpriteRenderer>().sprite = mapUpdates[8];
            GameObject.Find("Nodes").transform.GetChild(6).gameObject.SetActive(false);
            if (mapUpdateClipHasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(MapUpdateClip);
                mapUpdateClipHasPlayed = true;
            }
        }

        MovePlayer();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray02 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit02;
            if (Physics.Raycast(ray02, out hit02))
            {
                //If raycast hits a Node, move player to node
                if (hit02.transform.name == "Node01")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node02")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node03")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node04")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node05")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node06")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node07")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node08")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Node09")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Den00")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                //If raycast hits a den, this will check player prefs before moving to location
                if (hit02.transform.name == "Den01")
                {
                    Debug.Log("This is a second den node");
                    if (PlayerPrefs.GetInt("StoredFood") >= 5 && PlayerPrefs.GetInt("Cub") == 2)
                    {
                        Debug.Log("Requirements for den move met!");
                        selectedNode = hit02.transform.gameObject;
                        playerMoving = true;
                    }
                    else
                    {
                        Debug.Log("Should activate box now!");
                        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                        Debug.Log("Box activated!");
                    }

                }
                if (hit02.transform.name == "Den02")
                {
                    Debug.Log("This is a second den node");
                    if (PlayerPrefs.GetInt("StoredFood") >= 10 && PlayerPrefs.GetInt("Cub") == 2)
                    {
                        selectedNode = hit02.transform.gameObject;
                        playerMoving = true;
                    }
                    else
                    {
                        Debug.Log("Should activate box now!");
                        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                        Debug.Log("Box activated!");
                    }

                }
                if (hit02.transform.name == "Den03")
                {
                    Debug.Log("This is a second den node");
                    if (PlayerPrefs.GetInt("StoredFood") >= 15 && PlayerPrefs.GetInt("Cub") == 2)
                    {
                        selectedNode = hit02.transform.gameObject;
                        playerMoving = true;
                    }
                    else
                    {
                        Debug.Log("Should activate box now!");
                        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                        Debug.Log("Box activated!");
                    }

                }
            }
        }
    }
}
