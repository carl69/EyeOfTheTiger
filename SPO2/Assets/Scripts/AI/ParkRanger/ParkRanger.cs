using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRanger : MonoBehaviour
{

    private Rigidbody rb;
    public float velocity = 5, distance2 = 10, distance3 = 11, velocity2 = -5;
    bool escapeRight = false, escapeLeft = false, unavez = false;
    public GameObject tigre;
    public float distance = 20, mayor0 = 0;
    public GameObject[] players;
    int counter = 0;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        tigre = GameObject.FindGameObjectWithTag("Cub");
        players = new GameObject[10];


    }

    void Update()
    {

        if (escapeRight /*&& (transform.position.x > tigre.transform.position.x)*/)
        {
            print("3");
            if (!unavez)
            {
                print("5");
                players[counter] = tigre;
                counter++;
                unavez = true;
            }
            if (+transform.position.x - tigre.transform.position.x >= distance2/* -transform.position.x + tigre.transform.position.x >= distance2*/)
            {
                print("7");
                rb.velocity = new Vector2(velocity2, rb.velocity.y);
                //transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, velocity * Time.deltaTime);
            }
        }
        if (escapeLeft /*&& (transform.position.x < tigre.transform.position.x)*/)
        {
            print("4");
            if (!unavez)
            {
                print("6");
                players[counter] = tigre;
                counter++;
                unavez = true;
            }
            if (-transform.position.x + tigre.transform.position.x >= distance3)
            {
                print("8");
                rb.velocity = new Vector2(velocity, rb.velocity.y);
                //transform.position = Vector2.MoveTowards (transform.position, tigre.transform.position, -1 * velocity2 * Time.deltaTime);
            }
        }
        checkDistancia();
    }

    void checkDistancia()
    {
        //The part comment is if the game is in negative part
        if (!escapeRight && (transform.position.x < 0 && +transform.position.x - tigre.transform.position.x <= distance && +transform.position.x - tigre.transform.position.x >= mayor0) /*|| (transform.position.x > 0 &&  transform.position.x - tigre.transform.position.x <= distance  &&  transform.position.x - tigre.transform.position.x >= mayor0)*/)
        {
            escapeRight = true;
            print("1");
        }
        if (!escapeLeft && (transform.position.x < 0 && -transform.position.x + tigre.transform.position.x <= distance && -transform.position.x + tigre.transform.position.x >= mayor0) /*|| (transform.position.x > 0 && -transform.position.x + tigre.transform.position.x <= distance && -transform.position.x + tigre.transform.position.x >= mayor0 )*/)
        {
            escapeLeft = true;
            print("2");
        }
    }

}
