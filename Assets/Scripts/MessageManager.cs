using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour {

	public GameObject MessageDisplay;
	public GameObject ScoreDisplay;

	public String defaultMessage;
	String currentMessage;

	TextMesh message;
	TextMesh score;

	float scoreV=0;
	float ballV=3;

	float messageTime = 0;

	// Use this for initialization
	void Start () {
		message = MessageDisplay.GetComponent<TextMesh> ();
		score = ScoreDisplay.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		messageTime -= Time.deltaTime;
		if (messageTime < 0) {

			message.text = defaultMessage;

		}

	}

	public void SetMessage(String mess,float t)
	{
		currentMessage=mess.Substring(0, Math.Min(13, mess.Length));
		message.text = currentMessage;
		messageTime = t;
	}

	public void ChangeScore(float score){
		scoreV = Math.Min(score,99999999);
		UpdateScores ();
	}

	public void ChangeBall(float ball){
		ballV = Math.Min(ball,99);
		UpdateScores ();
	}

	void UpdateScores(){

		this.score.text = scoreV.ToString("00000000")+"   B:"+ballV.ToString("00");

	}
}
