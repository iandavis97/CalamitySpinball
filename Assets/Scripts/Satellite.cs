using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

	Rigidbody rb;
	AudioSource audio;

	float spinTime=0;
	float spinValue=10;
	float mult = 1;

	public AudioClip staticClip;
	public AudioClip transmissionClip;
	public AudioClip contactClip;
	public AudioClip scienceClip;
	public AudioClip madnessClip;


	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		audio = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (spinTime - Time.deltaTime < 0 && spinTime >= 0)
			mult *= -1;

		spinTime -= Time.deltaTime;

		if (spinTime > 0) {
			spinValue = 360;
		} 
		else {
			spinValue = 20;
		}

		//RotateAround (gameObject.transform.position, new Vector3 (0, 1, 0), spinValue * Time.deltaTime * mult);


	}

	void FixedUpdate()
	{
		Quaternion quat = Quaternion.Euler(new Vector3 (0, spinValue * Time.deltaTime * mult, 0));

		rb.MoveRotation(rb.rotation*quat);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball"&&spinTime<0) {
			spinTime = 2;
			RandomTransmission ();
		}
	}

	void RandomTransmission()
	{
		int i = Random.Range (0,99);

		if (i < 75) {
			ScoreSystem.IncreaseScore (200);
			audio.PlayOneShot (staticClip);
			ScoreSystem.MessageManager.SetMessage("No Signal",4);
		} 
		else if (i < 88) {
			ScoreSystem.IncreaseScore (500);
			audio.PlayOneShot (transmissionClip);
			ScoreSystem.MessageManager.SetMessage("Transmission",4);
		} 
		else if (i < 95) {
			ScoreSystem.IncreaseScore (500);
			audio.PlayOneShot (contactClip);
			ScoreSystem.MessageManager.SetMessage("First Contact",4);
			Abduction.main.DropBall ();
		} 
		else if (i < 98) {
			ScoreSystem.IncreaseScore (1000);
			audio.PlayOneShot (scienceClip);
			ScoreSystem.MessageManager.SetMessage("New Discovery",4);
			ScoreSystem.SetMultiplier (2,30);
		} 
		else {
			ScoreSystem.IncreaseScore (2000);
			audio.PlayOneShot (madnessClip);
			ScoreSystem.MessageManager.SetMessage("Space Madness",4);
			ScoreSystem.Ball = ScoreSystem.Ball + 1;
		}


	}
}
