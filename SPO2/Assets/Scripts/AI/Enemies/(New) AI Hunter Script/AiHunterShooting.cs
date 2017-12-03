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

    public AudioSource ShotSource;
    public AudioClip ShotClip;
    public AudioClip ReloadClip;
    public bool hasReloaded = false;

    public GameObject BulletSpawnPoint;
    // Use this for initialization
    void Start () {

        ShotSource = gameObject.GetComponent<AudioSource>();
        
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        if (fireRate < fireTimer)
        {
            Rigidbody clone;
            clone = Instantiate(bullet, BulletSpawnPoint.transform.position, Quaternion.AngleAxis(transform.rotation.eulerAngles.y + 90, Vector3.up)/*transform.rotation*/) as Rigidbody;
            ShotSource.PlayOneShot(ShotClip, 1.0f);
            clone.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed * Time.deltaTime);
            Destroy(clone.gameObject, 1f);
            fireTimer = 0;
            hasReloaded = false;
        }
        else {
            fireTimer += Time.deltaTime * 1;
            if (hasReloaded == false && fireRate/2.5 < fireTimer)
            {
                ShotSource.PlayOneShot(ReloadClip, 0.1f);
                hasReloaded = true;
            }
        }
	}
}
