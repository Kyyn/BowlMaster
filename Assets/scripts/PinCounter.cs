using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private float lastChangeTime;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;


    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            //standingDisplay.color = Color.red; // mio lo hago en LaneBox
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }


    int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }

    void UpdateStandingCountAndSettle()
    {
        // Update LastStandingCount
        // Call PinsHaveSettle when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;

        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
            standingDisplay.color = Color.red;
        }
    }
}
