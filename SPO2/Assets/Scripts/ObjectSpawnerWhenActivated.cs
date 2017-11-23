using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerWhenActivated : MonoBehaviour {
    public GameObject Spawn;
    Transform rot;

    public AudioSource CubSpawnSource;
    public AudioClip CubSpawnClip;

    public string playerprefsKey = "Den";
    public int playerprefsLevel = 1;
	// Use this for initialization
	void Start () {

        CubSpawnSource = GameObject.FindGameObjectWithTag("AudioController").transform.GetChild(1).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt(playerprefsKey) <= playerprefsLevel)
        {
            int getplayerprefs = PlayerPrefs.GetInt(playerprefsKey);
            PlayerPrefs.SetInt(playerprefsKey, getplayerprefs + 1);
            print(getplayerprefs + "  " + PlayerPrefs.GetInt(playerprefsKey));
        }

        CubSpawnSource.PlayOneShot(CubSpawnClip);
        Instantiate(Spawn, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(0,90,0));
        this.gameObject.SetActive(false);
	}
    
}
