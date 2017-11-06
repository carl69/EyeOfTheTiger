using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubSceneManager : MonoBehaviour {
    public int Days;
    public int CubLevel;
    public int StoredFood;

    public bool DebugPlayerPrefs = false;
    public bool Cheats = false;
    private void Awake()
    {
        Days = PlayerPrefs.GetInt("Days");
        CubLevel = PlayerPrefs.GetInt("CubLevel");
        StoredFood = PlayerPrefs.GetInt("StoredFood");
    }
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Cheats
        if (Cheats)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        Days += 1;
                    }
                    else if(Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        Days -= 1;
                    }
                }
                else if(Input.GetKey(KeyCode.C))
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        CubLevel += 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        CubLevel -= 1;
                    }
                }
                else if(Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        StoredFood += 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        StoredFood -= 1;
                    }
                }
            }
        }

        //Checks if playerprefs needs an update
        if (Days != PlayerPrefs.GetInt("Days"))
        {
            UpdatePlayerPrefs();
        }
        if (CubLevel != PlayerPrefs.GetInt("CubLevel"))
        {
            UpdatePlayerPrefs();
        }
        if (StoredFood != PlayerPrefs.GetInt("StoredFood"))
        {
            UpdatePlayerPrefs();
        }
    }
    private void OnApplicationQuit()
    {
        UpdatePlayerPrefs();
    }
    void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetInt("Days", Days);
        PlayerPrefs.SetInt("CubLevel", CubLevel);
        PlayerPrefs.SetInt("StoredFood", StoredFood);

        if (DebugPlayerPrefs)
        {
            print("PlayerPrefs Updated");
            print("Days = " + PlayerPrefs.GetInt("Days").ToString());
            print("CubLevel = " + PlayerPrefs.GetInt("CubLevel").ToString());
            print("StoredFood = " + PlayerPrefs.GetInt("StoredFood").ToString());
        }


    }

}
