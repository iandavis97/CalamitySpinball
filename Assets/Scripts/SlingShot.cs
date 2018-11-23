using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour {
	[SerializeField]
	float force;
	[SerializeField]
	GameObject direction;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		Vector3 forceDir = Vector3.Normalize(direction.transform.position - this.transform.position) * force;
		other.gameObject.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
	}
}
