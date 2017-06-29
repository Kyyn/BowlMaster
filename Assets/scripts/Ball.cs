using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour {
    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody myrigidbody;
    private AudioSource audioSource;
    private Vector3 ballStartPos; 

	// Use this for initialization
	void Start ()
    {
        ballStartPos = transform.position; 
        myrigidbody = GetComponent<Rigidbody>();
        myrigidbody.useGravity = false;


    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        myrigidbody.useGravity = true;
        myrigidbody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        myrigidbody.velocity = new Vector3(0,0,0);
        myrigidbody.angularVelocity = new Vector3(0, 0, 0); // can use Vector3.zero instead
        myrigidbody.useGravity = false;
    }

}
