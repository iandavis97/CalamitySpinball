using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	[SerializeField]
	GameObject forceApplicator;	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * 15, forceApplicator.transform.position, ForceMode.Impulse);
		}
	}
}
