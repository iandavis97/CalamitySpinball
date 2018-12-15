using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLights : MonoBehaviour 
{
	[SerializeField]
	Light[] leftPaddleLights;
	[SerializeField]
	Light[] rightPaddleLights;
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			StartCoroutine(ToggleLeftLights(0, 5, .5f));
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			StartCoroutine(ToggleRightLights(0, 5, .5f));
		}
	}
	IEnumerator ToggleLeftLights(int times, int limit, float delay)
	{
		for (int i = 0; i < leftPaddleLights.Length; ++i)
		{
			leftPaddleLights[i].gameObject.SetActive(!leftPaddleLights[i].gameObject.activeInHierarchy);
		}
		yield return new WaitForSeconds(delay);
		if (times < limit)
		{
			++times;
			StartCoroutine(ToggleLeftLights(times, limit, delay));
		}
	}

	IEnumerator ToggleRightLights(int times, int limit, float delay)
	{
		for (int i = 0; i < rightPaddleLights.Length; ++i)
		{
			rightPaddleLights[i].gameObject.SetActive(!rightPaddleLights[i].gameObject.activeInHierarchy);
		}
		yield return new WaitForSeconds(delay);
		if (times < limit)
		{
			++times;
			StartCoroutine(ToggleRightLights(times, limit, delay));
		}
	}
}
