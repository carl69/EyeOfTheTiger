using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeLoader : MonoBehaviour
{

    public string nodeName;

    // Use this for initialization
    void Start()
    {
        nodeName = this.name.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("WorldMap").GetComponent<WorldMap>().playerMoving = false;
            SceneManager.LoadScene(nodeName);
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
