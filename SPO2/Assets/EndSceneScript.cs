using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour {


    public void Restart() {
        SceneManager.LoadScene(1);
    }
    public void GoTOMainMenu() {
        SceneManager.LoadScene(0);
    }
}
