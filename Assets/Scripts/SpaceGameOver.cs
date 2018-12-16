using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGameOver : MonoBehaviour {

	public AudioClip clip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GameOver(){
		ScoreSystem.MessageManager.SetMessage ("SPACE OUT",30);
		AudioSource audio=GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource> ();
		audio.Stop ();
		audio.clip = clip;
		audio.Play ();
	}
}
