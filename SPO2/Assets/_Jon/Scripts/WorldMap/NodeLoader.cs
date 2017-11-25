using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeLoader : MonoBehaviour
{
    public Scene sceneToLoad;
    public string nodeName;

    int homeRemember;
    // Use this for initialization
    void Start()
    {
        nodeName = this.name.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("WorldMapController").GetComponent<WorldMap>().playerMoving = false;
            //Debug.Log("playerMoving set to false!");
            SceneManager.LoadScene(nodeName);
            //Debug.Log("Loading scene:" + nodeName);
            if(nodeName.Contains("Den"))
            {
                homeRemember = PlayerPrefs.GetInt("Home") + 1;

                PlayerPrefs.SetInt("Home", homeRemember);
                PlayerPrefs.SetInt("Den", 0);
                PlayerPrefs.SetInt("Cub", 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == this.name)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }

        }
    }
}
