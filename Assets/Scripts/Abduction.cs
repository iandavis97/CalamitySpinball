using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abduction : MonoBehaviour {

	public bool active = true;

	GameObject cBall=null;

	Light light;

	float abdTime = -20;
	Vector3 abdPos;

	public string[] abdMessages;

	public static Abduction main; 

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = gameObject.GetComponent<AudioSource> ();
		light = gameObject.GetComponent<Light> ();
		main = this;
	}
	
	// Update is called once per frame
	void Update () {

		if (active && !Captured() && abdTime<0) {
			light.enabled = true;
		} else
			light.enabled=false;



		if (abdTime >= -1 && abdTime - Time.deltaTime < -1) {
			SpawnNewBall ();
			cBall.GetComponent<Rigidbody> ().isKinematic = true;
			GameObject music=GameObject.FindGameObjectWithTag ("Music");
			music.GetComponent<AudioSource> ().Play();
		}

		abdTime -= Time.deltaTime;

		if(cBall!=null)
		cBall.transform.position = Vector3.Lerp (transform.position, abdPos, abdTime);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Ball" && active && !Captured()) {
			audio.Play ();
			GameObject music=GameObject.FindGameObjectWithTag ("Music");
			music.GetComponent<AudioSource> ().Pause();
			cBall=other.gameObject;
			active = false;
			abdTime = 4;
			abdPos = cBall.transform.position;
			ScoreSystem.MessageManager.SetMessage (abdMessages[Random.Range(0,abdMessages.Length)],5);
		}

	}

	void SpawnNewBall(){
		BallManager manager = GameObject.FindGameObjectWithTag ("BallManager").GetComponent<BallManager>();

        manager.AddBall();

	}

	public void DropBall(){
		if (Captured()) {
			cBall.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			cBall = null;
			cBall.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	public bool Captured(){

		return !(cBall==null);

	}
}
