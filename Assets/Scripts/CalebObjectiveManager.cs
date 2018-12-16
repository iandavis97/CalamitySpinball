using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalebObjectiveManager : MonoBehaviour 
{
	int keysRemaining = 3;
	[SerializeField]
	GameObject gate;
	[SerializeField]
	Key[] keys;
	[SerializeField]
	Diamond diamond;
	bool objectiveComplete = false;
	public bool ObjectiveComplete
	{
		get
		{
			return objectiveComplete;
		}
	}
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RemoveKey()
	{
		--keysRemaining;
		if (keysRemaining == 0)
		{
			OpenGate();
		}
	}

	void OpenGate()
	{
		gate.SetActive(false);
	}
	public void ResetObjective()
	{
		foreach (Key k in keys)
		{
			k.gameObject.SetActive(true);
			
		}
		diamond.gameObject.SetActive(true);
		gate.SetActive(true);
	}
}
