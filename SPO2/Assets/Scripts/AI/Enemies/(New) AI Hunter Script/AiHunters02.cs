using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHunters02 : MonoBehaviour {
    [Range(30f, 0f)]
    public float fpsTargetDistance;
    [Range(30f, 0f)]
    public float enemyLookDistance;
    [Range(30f, 0f)]
    public float moveToAttackDistance;
    [Range(30f, 0f)]
    public float shootDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody rb;
    Renderer myRenderer;
    AiHunterShooting aihunterShooting;
    AiHunterIdel aihunteridel;
    // Use this for initialization
    void Start () {
        myRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        aihunterShooting = GetComponent<AiHunterShooting>();
        aihunteridel = GetComponent<AiHunterIdel>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (fpsTarget != null)
        {
            if (fpsTarget.gameObject.layer == 14)
            {
                aihunterShooting.enabled = false;

                fpsTarget = null;
            }

            fpsTargetDistance = Vector3.Distance(fpsTarget.transform.position, transform.position);

            if (fpsTargetDistance < moveToAttackDistance)
            {

                attack();
                lookAtPlayer();


            }
            else if (aihunterShooting.enabled == true)
            {
                aihunterShooting.enabled = false;
            }

            if (fpsTargetDistance < enemyLookDistance)
            {
                myRenderer.material.color = Color.yellow;
                lookAtPlayer();

                if (aihunteridel.enabled == true)
                {
                    aihunteridel.enabled = false;
                }
                //if (aihunterShooting.enabled == true)
                //{
                //    aihunterShooting.enabled = false;
                //}

            }
            else
            {

                if (aihunteridel.enabled == false)
                {
                    aihunteridel.enabled = true;
                }

                myRenderer.material.color = Color.white;
            }
        }
        else
        {
            if (aihunteridel.enabled == false)
            {
                aihunteridel.enabled = true;
            }
            //if (aihunterShooting.enabled == true)
            //{
            //    aihunterShooting.enabled = false;
            //}
            myRenderer.material.color = Color.white;
        }
	}

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
    void attack()
    {
        if (fpsTargetDistance < shootDistance)
        {


            myRenderer.material.color = Color.black;
            if (aihunterShooting.enabled == false)
            {
                aihunterShooting.enabled = true;
            }

        }
        else
        {
            myRenderer.material.color = Color.red;
            transform.position += (transform.forward * enemyMovementSpeed * Time.deltaTime);
        }
    }
}
