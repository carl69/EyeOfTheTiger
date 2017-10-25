using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootingScript : MonoBehaviour {
    public GameObject Bullet;
    public GameObject spawnPoint;

    public AudioClip gunShot;

    public float speed;

    bool shoot = false;
    public float fireRate = 4;
    float timer = 0;

	
	// Update is called once per frame
	void Update () {
        if (shoot == true && timer <= 0)
        {
            timer = fireRate;




            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, spawnPoint.transform.position, this.transform.rotation) as GameObject;

            GetComponent<AudioSource>().PlayOneShot(gunShot);

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.right * speed * Time.deltaTime);

        }
        else if (shoot == true)
        {
            timer -= 1 * Time.deltaTime;
        }
        else if(timer != 1){
            timer = 1;
        }

	}

    private void OnTriggerEnter(Collider p)
    {
		if (p.tag == "Player" || p.tag == "Cub" || p.tag == "Mother" || p.tag == "Pray")
        {
            shoot = true;
        }
    }
    private void OnTriggerExit(Collider p)
    {
		if (p.tag == "Player" || p.tag == "Cub" || p.tag == "Mother" || p.tag == "Pray")
        {
            shoot = false;
        }
    }
}
