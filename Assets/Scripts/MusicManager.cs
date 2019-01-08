using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour 
{
	AudioSource audio;
	[SerializeField]
	AudioClip[] clips;
	int clipIndex = 0;
	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
		audio.clip = clips[clipIndex];
		BallManager.OnLoseLife += ChangeMusic;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void ChangeMusic()
	{
		StartCoroutine(WaitToChangeClip());
	}

	IEnumerator WaitToChangeClip()
	{
		while (audio.time > .05)
		{
			yield return new WaitForEndOfFrame();
		}
		++clipIndex;
		float currentTime = audio.time;
		audio.clip = clips[clipIndex];
		audio.Play();		
	}
}
