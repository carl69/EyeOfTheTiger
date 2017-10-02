using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAnimatorController : MonoBehaviour {
    public GameObject Tiger;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Tiger.GetComponent<Movement>().isGrounded==true)anim.SetBool("IsGrounded", true);
        else anim.SetBool("IsGrounded", false);

        if (Tiger.GetComponent<PlayerWater>().drinkAudio == true) anim.SetBool("IsDrinking", true);
        else anim.SetBool("IsDrinking", false);

        anim.SetFloat("xMovement", Tiger.GetComponent<Movement>().xMovement);
        anim.SetFloat("yMovement", Tiger.GetComponent<Movement>().yMovement);

        /*if (Input.GetKeyDown(KeyCode.W))
            transform.forward = new Vector3(0f, 0f, 1f);
        else if (Input.GetKeyDown(KeyCode.S))
            transform.forward = new Vector3(0f, 0f, -1f);
            */
        if (Tiger.GetComponent<Movement>().xMovement<0)
            transform.forward = new Vector3(-1f, 0f, 0f);
        else if (Tiger.GetComponent<Movement>().xMovement > 0)
            transform.forward = new Vector3(1f, 0f, 0f);
    }
}
