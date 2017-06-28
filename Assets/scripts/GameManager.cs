﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;

	// Use this for initialization
	void Start () {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bowl (int pinFall)
    {
        bowls.Add(pinFall);

        ActionMaster.Action nextActon = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(nextActon);
        ball.Reset();
    }
}