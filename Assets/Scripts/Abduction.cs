using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abduction : MonoBehaviour {

	public bool active = true;

	GameObject cBall=null;

	Light light;

	float abdTime = -20;
	Vector3 abdPos;

	// Use this for initialization
	void Start () {
		light = gameObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (active && !Captured() && abdTime<0) {
			light.enabled = true;
		} else
			light.enabled=false;



		if (abdTime >= -1 && abdTime - Time.deltaTime < -1)
			SpawnNewBall ();

		abdTime -= Time.deltaTime;

		if(cBall!=null)
		cBall.transform.position = Vector3.Lerp (transform.position, abdPos, abdTime);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Ball" && active && !Captured()) {

			cBall=other.gameObject;
			abdTime = 4;
			abdPos = cBall.transform.position;
		}

	}

	void SpawnNewBall(){
		BallManager manager = GameObject.FindGameObjectWithTag ("BallManager").GetComponent<BallManager>();

		manager.ball=manager.CreateBall ();

	}

	bool Captured(){

		return !(cBall==null);

	}
}
