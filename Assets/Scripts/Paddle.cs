using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	[SerializeField]
	GameObject forceApplicator;
    AudioSource sound;//sound effect when activated

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * 15, forceApplicator.transform.position, ForceMode.Impulse);
            if (sound.isPlaying == false)
                sound.Play();
		}
	}
}
