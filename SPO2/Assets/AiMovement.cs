using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {
    public GameObject player;
    public float aiSpeed;

    Transform ground_right,ground_left;
    public LayerMask jumpWhenMeet;
    public bool isJumpingRight = false;
    public bool isJumpingLeft = false;

    public float jumpHight;
    Rigidbody2D AiBodi;
	// Use this for initialization
	void Start () {
        AiBodi = this.GetComponent<Rigidbody2D>();


        ground_right = GameObject.Find(this.name + "/tag_AIground_Right").transform;
        ground_left = GameObject.Find(this.name + "/tag_AIground_Left").transform;

    }

    // Update is called once per frame
    void Update () {

        isJumpingRight = Physics2D.Linecast(this.transform.position, ground_right.position, jumpWhenMeet);
        isJumpingLeft = Physics2D.Linecast(this.transform.position, ground_left.position, jumpWhenMeet);



        if (isJumpingLeft || isJumpingRight)
        {
            Jump();
        }


        float step = aiSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);


	}

    void Jump() {
        AiBodi.AddForce(transform.up * jumpHight *Time.deltaTime);

    }
}
