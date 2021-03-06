﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMoveInAir = true;
    [HideInInspector]
    private float speed = 10f, jumpVelocity = 10f, gravityStrength, addedRunningSpeed;
    //[HideInInspector]
    public float currRunningSpeed = 0;
    public LayerMask playerMask;
    Transform myTransform, tagGround;
    Rigidbody myBody;
   // [HideInInspector]
    public bool isGrounded = false;
    public bool updateStats;

    public float jumping = 1;
    private bool jumped;

    public float xMovement;
    public float yMovement;
    // Use this for initialization
    void Awake()
    {

        CheckStats();

        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.GetButton("Jump") && jumped == false )
        {
            jumped = true;
            Jump();
            jumping = 0.3f;
        }
        else if (jumped == true && jumping <= 0)
        {
            jumped = false;
        }
        if (jumping > 0)
        {
            jumping -= 1 * Time.deltaTime;
        }


        if (myBody == null)
        {
            CheckStats();
        }

        xMovement = myBody.velocity.x;
        yMovement = myBody.velocity.y;

        //Debug.Log(yMovement);

        if (myBody == null)
        {
            CheckStats();

            myBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            myTransform = GameObject.FindGameObjectWithTag("Player").transform;
            tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        }

        if (updateStats) {
            CheckStats();
        }



        isGrounded = Physics.Linecast(myTransform.position, tagGround.position, playerMask);

        Move(Input.GetAxisRaw("Horizontal"));
        



        //myBody.AddForce(Physics.gravity, ForceMode2D.Force);
    }

    public void Move(float horizonalInput)
    {
        if (!canMoveInAir && !isGrounded)
        {
            return;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currRunningSpeed = addedRunningSpeed;
        }
        else {
            currRunningSpeed = 0;
        }

        //myBody.velocity = new Vector2 (horizonalInput * speed,0);
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * (speed + currRunningSpeed) * Time.deltaTime;
        myBody.velocity = moveVel;

    }

    public void Jump()
    {
        //Checks if you are standing on the ground
        if (isGrounded)
        {
            myBody.AddForce(transform.up * jumpVelocity*Time.deltaTime);


        }
    }
    public void CheckStats() {
        //Finds the player stats script
        playerStats Playstats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();
        //Sets the gravity variable in this script
        gravityStrength = Playstats.gravity;
        //change the ingame gravity
        Vector2 gravityS = new Vector2(0, gravityStrength);
        Physics.gravity = gravityS;
        //Change jump varible
        jumpVelocity = Playstats.jumphight;
        //change speed varible
        speed = Playstats.playerSpeed;
        // add running speed var
        addedRunningSpeed = Playstats.Running;


        myBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        myTransform = GameObject.FindGameObjectWithTag("Player").transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

}
