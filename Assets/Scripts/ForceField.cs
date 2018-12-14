using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour {

	float time;
	public float health=100;

	public AudioClip hit;
	public AudioClip down;

	Renderer renderer;
	Light light;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		audio = GetComponent<AudioSource> ();
		light = gameObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime;



		Color c = this.renderer.material.color;
		c.a=Mathf.Lerp(0,0.5f,time*2);
		this.renderer.material.color = c;

		light.intensity = Mathf.Lerp(0,1,time*2);

		if (health > 0) {
			health += Time.deltaTime / 0.75f;
			health = Mathf.Min (health, 100);
			gameObject.GetComponent<Collider> ().isTrigger = false;
		} else {
			gameObject.GetComponent<Collider> ().isTrigger = true;
		}
			

	}

	void OnCollisionEnter(Collision col){
		time = 0.5f;

		health -= 20;

		GameObject other = col.gameObject;

		Vector3 dir=other.transform.position-transform.position;
		dir.Normalize ();

		other.GetComponent<Rigidbody> ().AddForce (dir*1.5f);

		if (health > 0) {
			ScoreSystem.MessageManager.SetMessage ("Shield at " + health.ToString ("00") + "%",5);
			ScoreSystem.IncreaseScore (250);
			audio.pitch=2-health/100.00f;
			audio.PlayOneShot (hit);
		} 
		else {
			ScoreSystem.MessageManager.SetMessage ("Shields down!",5);
			ScoreSystem.IncreaseScore (750);
			audio.pitch=2;
			audio.PlayOneShot (hit);
			audio.pitch = 1;
			audio.PlayOneShot (down);
		}
	}
}
