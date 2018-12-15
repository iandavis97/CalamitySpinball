using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerLights : MonoBehaviour 
{
	[SerializeField]
	Light[] lights;	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			StartCoroutine(ToggleLights(0, 5, .5f));
		}
	}

	IEnumerator ToggleLights(int times, int limit, float delay)
	{
		for (int i = 0; i < lights.Length; ++i)
		{
			lights[i].gameObject.SetActive(!lights[i].gameObject.activeInHierarchy);
		}
		yield return new WaitForSeconds(delay);
		if (times < limit)
		{
			++times;
			StartCoroutine(ToggleLights(times, limit, delay));
		}

	}
}
