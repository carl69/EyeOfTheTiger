using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed, dur;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        //Destroy(this.gameObject, dur);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(transform.position.x)
        //rb.velocity = transform.forward;
        //rb.AddForce(Vector2.left * speed * Time.deltaTime);
    }
}
