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
        if(Tiger.GetComponent<Movement>().isGrounded==true)anim.SetBool("isGrounded", false);
        else anim.SetBool("isGrounded", true);

        anim.SetFloat("xMovement", Tiger.GetComponent<Movement>().xMovement);
        anim.SetFloat("yMovement", Tiger.GetComponent<Movement>().yMovement);
    }
}
