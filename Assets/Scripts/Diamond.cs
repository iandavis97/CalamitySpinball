using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour 
{
	CalebObjectiveManager manager;
	void Start()
	{
		manager = GetComponentInParent<CalebObjectiveManager>();
	}
	// Update is called once per frame
	void Update () 
	{
		transform.localRotation *= Quaternion.AngleAxis(50 * Time.deltaTime, Vector3.up);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			gameObject.SetActive(false);
			ScoreSystem.IncreaseScore(1000);
		}
	}
}
