using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootingScript : MonoBehaviour {
    public GameObject Bullet;
    public GameObject spawnPoint;


    public float speed;

	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider p)
    {
        if (p.tag == "Player" || p.tag == "Cub")
        {
            //Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0), parent.transform.rotation);

            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, spawnPoint.transform.position, this.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.right * speed * Time.deltaTime);




        }
    }
}
