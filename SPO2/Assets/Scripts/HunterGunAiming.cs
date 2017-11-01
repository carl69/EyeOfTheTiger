using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterGunAiming : MonoBehaviour {
    GameObject Player;
    public float speed = 5;
    public GameObject Parent;
    aiHunterStopAiming aiStopAim;
    Vector3 direction;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        aiStopAim = Parent.GetComponent<aiHunterStopAiming>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

        if (aiStopAim.TigerIsHere == true)
        {
            Vector3 dir = Player.transform.position - transform.position;
            //dir.y = 0; // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(dir);
            // slerp to the desired rotation over time
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

            //transform.LookAt(Player.transform);
        }
        
        //transform.rotation = Quaternion.LookRotation(transform.position - Player.transform.position);
    }
}
