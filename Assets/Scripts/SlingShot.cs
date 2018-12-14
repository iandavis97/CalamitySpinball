using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour {
	[SerializeField]
	float force;
	[SerializeField]
	GameObject direction;
    public int scoreToAdd;
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
		float dis = Vector3.Distance(other.collider.gameObject.transform.position,gameObject.transform.position)/2.6f;
		Vector3 forceDir = Vector3.Normalize(direction.transform.position - this.transform.position) * force;
		other.gameObject.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
        ScoreSystem.IncreaseScore(scoreToAdd);
	}
}
