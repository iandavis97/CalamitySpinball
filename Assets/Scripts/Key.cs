using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localRotation *= Quaternion.AngleAxis(50 * Time.deltaTime, Vector3.up);
	}
}
