using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

	Rigidbody rb;
	AudioSource audio;

	float spinTime=0;
	float spinValue=10;
	float mult = 1;

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
			ScoreSystem.IncreaseScore (200);
			spinTime = 2;
			audio.Play ();
		}
	}
}
