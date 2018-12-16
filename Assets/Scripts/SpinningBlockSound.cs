using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlockSound : MonoBehaviour 
{
	AudioSource source;
	// Use this for initialization
	void Start () 
	{
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			source.Play();
			ScoreSystem.IncreaseScore(5);
		}
	}
}
