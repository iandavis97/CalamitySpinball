using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour 
{
	[SerializeField]
	GameObject ball;
	Rigidbody rb;
	float forceMagnitude = 0;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.DownArrow))
		{
			forceMagnitude += .5f;
		}
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up * forceMagnitude);
		}
	}
}
