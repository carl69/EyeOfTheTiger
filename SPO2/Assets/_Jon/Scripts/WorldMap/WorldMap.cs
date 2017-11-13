using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMap : MonoBehaviour {

    public float speed;
    public GameObject selectedNode;

    public bool playerMoving = false;

	// Use this for initialization
	void Start () {
        
	}

    private void MovePlayer()
    {
        if (playerMoving == true)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.MoveTowards(GameObject.FindGameObjectWithTag("Player").transform.position, selectedNode.transform.position, speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update () {
       
            MovePlayer();
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray02 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit02;
            if(Physics.Raycast(ray02, out hit02))
            {                
                if(hit02.transform.name == "Node01")
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
                if (hit02.transform.name == "Tutorial_3")
                {
                    selectedNode = hit02.transform.gameObject;
                    playerMoving = true;
                }
                if (hit02.transform.name == "Den02")
                {
                    Debug.Log("This is a second den node");
                    if (PlayerPrefs.GetInt("StoredFood") == 10 && PlayerPrefs.GetInt("CubLevel") == 3)
                    {
                        selectedNode = hit02.transform.gameObject;
                        playerMoving = true;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
	}
}
