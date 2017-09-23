using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public GameObject TigerPrefab;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
            Instantiate(TigerPrefab, GameObject.FindGameObjectWithTag("Cub").transform.position, Quaternion.identity);
            Destroy(GameObject.FindGameObjectWithTag("Cub"));


        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
