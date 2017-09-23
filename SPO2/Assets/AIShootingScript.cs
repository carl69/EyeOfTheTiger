using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootingScript : MonoBehaviour {
    public GameObject Bullet;
    GameObject parent;
	// Use this for initialization
	void Start () {
        parent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D p)
    {
        if (p.tag == "Player" || p.tag == "Cub")
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0), parent.transform.rotation);




        }
    }
}
