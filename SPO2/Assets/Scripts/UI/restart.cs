using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
		SceneManager.LoadScene("prototype");
    }
    public void RestartGame() {
		SceneManager.LoadScene("prototype");


    }
}
