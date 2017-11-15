using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerFollow : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void FollowPlayer()
    {
        this.transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            FollowPlayer();
        }
    }
}
