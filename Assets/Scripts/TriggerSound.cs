using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collision other)
	{
		if (other.gameObject.tag == "Ball")
			gameObject.GetComponent<AudioSource> ().Play ();
	}
}
