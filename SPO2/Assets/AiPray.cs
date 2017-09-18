﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPray : MonoBehaviour {
    public Vector2[] walkLocations;
    Vector2 curTarget;
    private int target = 0;

    public float aiSpeed = 10;
    private int listSize;
	// Use this for initialization
	void Start () {
        listSize = walkLocations.Length;
        curTarget = walkLocations[target];
    }
	
	// Update is called once per frame
	void Update () {
        float step = aiSpeed * Time.deltaTime;
        float dist = Vector2.Distance(curTarget, this.transform.position);



        if (dist <= 5)
        {
            
            target = Random.Range(0,2);
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
