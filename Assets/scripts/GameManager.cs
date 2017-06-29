using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bowl (int pinFall)
    {
        bowls.Add(pinFall);
        ball.Reset();


        pinSetter.PerformAction(ActionMaster.NextAction(bowls));

        scoreDisplay.FillRollCard(bowls);
        
    }
}
