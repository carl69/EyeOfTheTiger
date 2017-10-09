using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayerMovement : MonoBehaviour
{

    public AudioClip[] footsteps;
    public AudioClip[] running;
    public AudioClip jump;


    public bool clipPlaying = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1 && GameObject.FindGameObjectWithTag("Player") == true)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (clipPlaying == false) && (transform.GetChild(0).GetComponent<AudioSource>().isPlaying == false && GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().isGrounded == true))
            {
                transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(footsteps[Random.Range(0, 3)]);
                // clipPlaying = true;
            }

            if (transform.GetChild(0).GetComponent<AudioSource>().isPlaying == true && GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().isGrounded == false)
            {
                transform.GetChild(0).GetComponent<AudioSource>().Stop();
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.GetChild(0).GetComponent<AudioSource>().Stop();
                clipPlaying = false;
            }

            if (Input.GetKeyDown(KeyCode.W) && transform.GetChild(1).GetComponent<AudioSource>().isPlaying == false && GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().isGrounded == true)
            {
                transform.GetChild(1).GetComponent<AudioSource>().PlayOneShot(jump);
            }
        }
        if (Time.timeScale == 1 && GameObject.FindGameObjectWithTag("Player") == true)
        {
            if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) && clipPlaying == false && (transform.GetChild(0).GetComponent<AudioSource>().isPlaying == false && GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().isGrounded == true))
            {
                transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(running[Random.Range(0, 4)]);
                // clipPlaying = true;
            }

            if (transform.GetChild(0).GetComponent<AudioSource>().isPlaying == true && GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().isGrounded == false)
            {
                transform.GetChild(0).GetComponent<AudioSource>().Stop();
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.GetChild(0).GetComponent<AudioSource>().Stop();
                clipPlaying = false;
            }

        }
    }
}
