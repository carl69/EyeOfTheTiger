using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_scarePoachers : MonoBehaviour {

    public Sprite ParkRangerTalkie;
    public Transform hunterTarget;
    public float speed;
    public bool chasePoacher = false;
    public GameObject WalkieTalkieSprite;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ParkRanger")
        {
            WalkieTalkieSprite.SetActive(true);
            other.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ParkRangerTalkie;
            chasePoacher = true;
        }
    }

    

    // Update is called once per frame
    void Update () {
       
        if(chasePoacher == true)
        {
            //Debug.Log("chasePoacher is true!");
            //float step = speed * Time.deltaTime;
            //GameObject.FindGameObjectWithTag("Enemie").transform.position = Vector3.MoveTowards(transform.position, hunterTarget.position, step);
            //Debug.Log("Hunter moving!");
        }

	}
}
