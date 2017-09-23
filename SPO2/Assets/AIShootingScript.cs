using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootingScript : MonoBehaviour {
    public GameObject Bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D p)
    {
        if (p.tag == "Player" || p.tag == "Cub")
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
    }
}
