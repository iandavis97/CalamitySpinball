using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {
	[SerializeField]
	float force;
    AudioSource sound;

    // Use this for initialization
    void Start () 
	{
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		Vector3 forceDir = Vector3.Normalize(other.transform.position - this.transform.position) * force;
		other.gameObject.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
        if (sound.isPlaying == false)
            sound.Play();
	}
}
