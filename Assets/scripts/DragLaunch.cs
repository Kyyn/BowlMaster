﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd; //mio
    private float startTime, endTime; //mio
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveStart(float amount)
    {
        if (!ball.inPlay)
        {
            float yPos = transform.position.y;
            float zPos = transform.position.z;
            float xPos = Mathf.Clamp(transform.position.x + amount, -50f, 50f);
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;


            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

            ball.Launch(launchVelocity);
        }
    }
}
