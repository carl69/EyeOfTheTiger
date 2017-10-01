﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Seeker))]


public class RunPray : MonoBehaviour
{
	public Transform target;
	public float updateRate = 2f;
	private Seeker seeker;
	private Rigidbody rb;
	public Path path;
	public float speed = 300f;
	public ForceMode fMode;
	public bool pathIsEnded = false;
	public float nextWaypointDistance = 15;
	private int currentWaypoint = 0;




	public float currRunningSpeed = 0;
	Rigidbody myBody;

	void Start()
	{
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody>();
		if (target == null)
		{
			Debug.LogError("No Player Found");
			return;
		}
		seeker.StartPath(transform.position, target.position, OnPathComplete);
		StartCoroutine(UpdatePath());
	}
	public void OnPathComplete(Path p)
	{
		//Debug.Log("we got a path. did it have an error?" + p.error);
		if (!p.error)
		{
			path = p;
			currentWaypoint = 0;
		}
	}

	IEnumerator UpdatePath()
	{
		if (target == null)
		{
			//Look for a target;
			//return false;
		}
		seeker.StartPath(transform.position, target.position, OnPathComplete);
		yield return new WaitForSeconds(1f / updateRate);
		StartCoroutine(UpdatePath());

	}

	private void FixedUpdate()
	{
		if (target == null)
		{
			//Look for a target;
			return;
		}
		if (path == null)
		{
			return;
		}
		if (currentWaypoint >= path.vectorPath.Count)
		{
			if (pathIsEnded)
			{
				return;
			}
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		// dir to next waypoint
		//Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		//dir *= speed * Time.fixedDeltaTime;

		//rb.AddForce(dir, fMode);


		float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
		if (dist > nextWaypointDistance)
		{


			//transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);





		}
		//Debug.Log(nextWaypointDistance);

		if (dist < nextWaypointDistance)
		{
			//currentWaypoint++;
			//transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}



}
