using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMap : MonoBehaviour {

    public float speed;
    public int food = 0;
    public bool cubLevel03 = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "Node01")
            {
                Debug.Log("Hovering over first waterfall");
                GameObject.Find("Node01").transform.GetChild(2).gameObject.SetActive(true);
               
            }
            else
            {
                GameObject.Find("Node01").transform.GetChild(2).gameObject.SetActive(false);
            }
         
        }
            if (Input.GetMouseButtonDown(0))
        {
            Ray ray02 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit02;
            if(Physics.Raycast(ray02, out hit02))
            {
                if(hit02.transform.name == "Node01")
                {
                    Debug.Log("This is a waterfall node");
                    GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.Find("Node01").transform.GetChild(0).transform.position, step);
                    SceneManager.LoadScene("Node01");
                }
                if (hit02.transform.name == "Node02")
                {
                    Debug.Log("This is a clearing node");
                    GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.Find("Node02").transform.GetChild(0).transform.position, step);
                }
                if (hit02.transform.name == "Node03")
                {
                    Debug.Log("This is a poacher camp node");
                    GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.Find("Node03").transform.GetChild(0).transform.position, step);
                }
                if (hit02.transform.name == "Den01")
                {
                    Debug.Log("This is a den node");
                    GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.Find("Den01").transform.GetChild(0).transform.position, step);
                }
                if (hit02.transform.name == "Den02")
                {
                    Debug.Log("This is a second den node");
                    if (food >= 10 && cubLevel03 == true)
                    {
                        GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.Find("Den02").transform.GetChild(0).transform.position, step);
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
