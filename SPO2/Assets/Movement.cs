using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float speed = 10f, jumpVelocity = 10f, gravityStrength;
    public LayerMask playerMask;
    Transform myTransform, tagGround;
    Rigidbody2D myBody;
    public bool isGrounded = false;
    public bool updateStats;


    
    // Use this for initialization
    void Start()
    {

        CheckStats();

        myBody = this.GetComponent<Rigidbody2D>();
        myTransform = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (updateStats) {
            CheckStats();
        }



        isGrounded = Physics2D.Linecast(myTransform.position, tagGround.position, playerMask);

        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }



        //myBody.AddForce(Physics.gravity, ForceMode2D.Force);
    }

    public void Move(float horizonalInput)
    {
        myBody.velocity = new Vector2(horizonalInput * speed, 0);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            myBody.AddForce(transform.up * jumpVelocity);
            //myBody.velocity += new Vector2(0, jumpVelocity);
            //myBody.AddForce(Vector2.up * jumpVelocity);
            //myBody.AddForce(new Vector2(0, jumpVelocity));


        }
    }
    public void CheckStats() {
        //Finds the player stats script
        playerStats Playstats = GameObject.Find("Player").GetComponent<playerStats>();
        //Sets the gravity variable in this script
        gravityStrength = Playstats.gravity;
        //change the ingame gravity
        Vector2 gravityS = new Vector2(0, gravityStrength);
        Physics2D.gravity = gravityS;
        //Change jump varible
        jumpVelocity = Playstats.jumphight;
        //change speed varible
        speed = Playstats.playerSpeed;
    }

}
