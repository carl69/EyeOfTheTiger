using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTargetFollow : MonoBehaviour {
    public float curentDistance;
    public float maxDistance;
    public float speed;
    public float timeBeforeIdel;
    public float timer;
    public float leftRight;
	// Use this for initialization
	void Start () {
        leftRight = Input.GetAxis("Horizontal");

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (timer < timeBeforeIdel)
        {
            timer += Time.deltaTime;
        }
        else
        {
            leftRight = Input.GetAxis("Horizontal");


        }

        if (Input.GetAxis("Horizontal") != 0/*Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1*/)
        {
            timer = 0;
            leftRight = Input.GetAxis("Horizontal");


            if (transform.localPosition.x * leftRight < maxDistance)//(transform.localPosition.x < maxDistance) && (transform.localPosition.x > -maxDistance))
            {

                curentDistance += leftRight * speed * Time.deltaTime;
                //curentDistance = maxDistance * leftRight;
                if (transform.localPosition.x * leftRight < maxDistance)
                {
                    transform.localPosition = new Vector3(curentDistance, 0, 0); //Vector3.MoveTowards(this.transform.position, new Vector3(curentDistance, 0, 0), speed*Time.deltaTime);//new Vector3(curentDistance, 0, 0);

                }

            }
        }
        else if(timer > timeBeforeIdel)
        {
            curentDistance = 0;
            transform.position = Vector3.MoveTowards(this.transform.position, transform.parent.position, speed * Time.deltaTime);
        }

	}

}
