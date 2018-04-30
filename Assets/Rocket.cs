using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	[SerializeField]
	private float rcsThrust = 250;
	[SerializeField]
	private float upperThrust = 10;
	private Rigidbody rigidbody;
	private AudioSource audioSource;
	// Use this for initialization;
	void Start () {
		audioSource = GetComponent<AudioSource>();
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Thrust();
		Rotate();
	}


    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float thrustSpeed = upperThrust*Time.deltaTime;
			rigidbody.AddRelativeForce(Vector3.up*thrustSpeed);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else audioSource.Stop();
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        float rotationSpeed = rcsThrust*Time.deltaTime;
		if (Input.GetKey(KeyCode.A))
        {	
            transform.Rotate(Vector3.forward*rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.forward*rotationSpeed);
        rigidbody.freezeRotation = false;
		}
		
}