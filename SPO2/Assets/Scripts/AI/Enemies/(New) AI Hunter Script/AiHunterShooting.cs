using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHunterShooting : MonoBehaviour {
    public Rigidbody bullet;
    [Range(1000.0f, 5000.0f)]
    public float bulletSpeed;
    [Range(0.01f, 5f)]
    public float fireRate;
    float fireTimer = 0;

    

    // Use this for initialization
    void Start () {
        
        
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        if (fireRate < fireTimer)
        {
            Rigidbody clone;
            clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed * Time.deltaTime);
            Destroy(clone.gameObject, 1f);
            fireTimer = 0;
        }
        else {
            fireTimer += Time.deltaTime * 1;
        }
	}
}
