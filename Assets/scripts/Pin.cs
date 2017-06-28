using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour {


    public float standingThreshold = 20f;
    public float distanceToRaise = 40f;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs (270 -rotationInEuler.x);
        float tiltInZ = Mathf.Abs (rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        } else
        {
            return false;
        }

    }

    public void Raise()
    {
            if (IsStanding())
            {
                transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
                transform.rotation = Quaternion.Euler(270, 0, 0);
                GetComponent<Rigidbody>().useGravity = false;
            }

    }

    public void Lower()
    {
                transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
                GetComponent<Rigidbody>().useGravity = true;
                   
    }
}
