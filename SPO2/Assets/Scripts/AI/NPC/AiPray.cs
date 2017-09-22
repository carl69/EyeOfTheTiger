using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPray : MonoBehaviour {
    public Vector2[] walkLocations;
    Vector2 curTarget;
    private int target = 0;
    public float turnDist = 5;
    public float aiSpeed = 10;
    private int listSize;

    public bool notSafe;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        listSize = walkLocations.Length;
        curTarget = walkLocations[target];
    }
	
	// Update is called once per frame
	void Update () {


        float step = aiSpeed * Time.deltaTime;
        float dist = Vector2.Distance(curTarget, this.transform.position);
        float dangerDist = Vector2.Distance(player.transform.position, this.transform.position);

        if (dangerDist < 10 && notSafe)
        {
            //transform.position += Vector3.right * step * 2;
            

        }
        else if (dist <= turnDist)
        {
            
            target = Random.Range(0,listSize);
            curTarget = walkLocations[target];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, curTarget, step);
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < listSize; i++)
        {
            
            if (i != listSize - 1)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(walkLocations[i], walkLocations[i + 1]);
            }
        }
    }
}
