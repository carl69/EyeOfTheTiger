using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapTransitionTo : MonoBehaviour {
    int days;
	// Use this for initialization
	void Start () {
        days = PlayerPrefs.GetInt("Days");
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            days += 1;
            PlayerPrefs.SetInt("Days",days);
            Debug.Log("Player entered trigger!");
            SceneManager.LoadScene("WorldMap");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
