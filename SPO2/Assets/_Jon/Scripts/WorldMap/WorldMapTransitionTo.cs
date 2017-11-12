using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapTransitionTo : MonoBehaviour {
    int days;
    // Use this for initialization
    void Start() {
        days = PlayerPrefs.GetInt("Days");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            days += 1;
            PlayerPrefs.SetInt("Days", days);
            Debug.Log("Player entered trigger!");
            if (PlayerPrefs.GetInt("Home") == 0)
            {
                SceneManager.LoadScene("Tutorial_3");
            }
            if(PlayerPrefs.GetInt("Home") == 1)
            {
                SceneManager.LoadScene("Den01");
            }

        }
    }
        // Update is called once per frame
        void Update() {

        }
}
