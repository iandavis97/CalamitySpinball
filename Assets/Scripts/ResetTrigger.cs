using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour 
{
	CalebObjectiveManager manager;
	Diamond diamond;
	// Use this for initialization
	void Start () 
	{
		manager = GetComponentInParent<CalebObjectiveManager>();
		diamond = FindObjectOfType<Diamond>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ball") && !diamond.isActiveAndEnabled)
		{
			manager.ResetObjective();
		}
	}
}
