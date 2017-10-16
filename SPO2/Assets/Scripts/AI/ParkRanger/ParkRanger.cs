using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRanger : MonoBehaviour
{
     float dist;

    private Rigidbody rb;
     float velocity = 5, distance2 = 10, distance3 = 10, velocity2 = -5;
    bool escapeRight = false, escapeLeft = false, unavez = false, unavez2 = false;
    public GameObject tigre;
    public float distance = 20, mayor0 = 10.0f;
    public GameObject[] players;
    int counter = 0;

    private SpriteRenderer checkmark;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
		tigre = GameObject.FindGameObjectWithTag("Cub");
        players = new GameObject[10];

        checkmark = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cub")
        {
            tigre = GameObject.FindGameObjectWithTag("Cub");
            Color alphaValue = checkmark.color;
            alphaValue.a = 1;             
            checkmark.color = alphaValue;
            Destroy(transform.GetChild(1).gameObject, 4);


        }
    }
    void Update()
    {
        dist = Vector2.Distance(tigre.transform.position, this.transform.position);
        if (dist < mayor0)
        {
            velocity2 = 0;
            velocity = 0;
        }else
        {
            velocity2 = -5;
            velocity = 5;
        }


        if (escapeRight /*&& (transform.position.x > tigre.transform.position.x)*/)
        {
            //escapeLeft = false;
            //print("3");
			if (!unavez)
            {
                //print("5");
                players[counter] = tigre;
                counter++;
                unavez = true;
            }
			//print (+transform.position.x - tigre.transform.position.x);
			if (+transform.position.x - tigre.transform.position.x > -2/* distance2*/){
				//print ("7");
				rb.velocity = new Vector2 (velocity2, rb.velocity.y);
               
				//transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, velocity * Time.deltaTime);
			}
        }
        if (escapeLeft /*&& (transform.position.x < tigre.transform.position.x)*/)
        {
            //escapeRight = false;
            //print("4");
			if (!unavez2)
            {
                //print("6");
                players[counter] = tigre;
                counter++;
                unavez2 = true;
            }
			if (-transform.position.x + tigre.transform.position.x > 2/*distance3*/ )
            {
                //print("8");
                rb.velocity = new Vector2(velocity, rb.velocity.y);
                
                //transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, -1 * velocity2 * Time.deltaTime);
			}
        }
        checkDistancia();
    }

    void checkDistancia()
    {

        //The part comment is if the game is in negative part
        if (!escapeRight &&  (transform.position.x > 0 &&  transform.position.x - tigre.transform.position.x <= distance  &&  transform.position.x - tigre.transform.position.x >= mayor0))
        {
            escapeRight = true;
            //print("1");
        }
        if (!escapeLeft && (transform.position.x > 0 && -transform.position.x + tigre.transform.position.x <= distance && -transform.position.x + tigre.transform.position.x >= mayor0 ))
        {
            escapeLeft = true;
            //print("2");
        }
    }

}
