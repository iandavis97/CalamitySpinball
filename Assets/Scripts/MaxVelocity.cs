using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxVelocity : MonoBehaviour {

	public float MaxVel=10;
	Rigidbody rigidB;

	// Use this for initialization
	void Start () {
		rigidB = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidB.velocity.magnitude > MaxVel) 
		{
			rigidB.velocity = rigidB.velocity.normalized*MaxVel;
		}
	}
}
