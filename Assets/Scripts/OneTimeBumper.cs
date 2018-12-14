using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeBumper : Bumper 
{
	
	new void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter(other);
		if (other.gameObject.CompareTag("Ball"))
		{
			this.transform.parent.gameObject.SetActive(false);
		}
	}
}
