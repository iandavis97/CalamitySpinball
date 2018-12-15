using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	float time;
	float health=100;

	public AudioClip hit;
	public AudioClip down;

	public GameObject ForceField;

	ForceField forceField;

	Renderer renderer;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		audio = GetComponent<AudioSource> ();
		forceField = ForceField.GetComponent<ForceField> ();
	}
	
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime;



		Color c = this.renderer.material.color;
		c.a=Mathf.Lerp(0,0.5f,time*2);
		this.renderer.material.color = c;

		if (health > 0) {
			health += Time.deltaTime / 0.75f;
			health = Mathf.Min (health, 100);
			gameObject.GetComponent<Collider> ().isTrigger = false;
		} else {
			health = 100;
		}
			

	}

	void OnCollisionEnter(Collision col){
		if (forceField.health <= 0) {
			time = 0.5f;

			health -= 20;

			GameObject other = col.gameObject;

			Vector3 dir = other.transform.position - transform.position;
			dir.Normalize ();

			other.GetComponent<Rigidbody> ().AddForce (dir * 1.5f);

			if (health > 0) {
				ScoreSystem.MessageManager.SetMessage ("Hull at " + health.ToString ("00") + "%", 5);
				ScoreSystem.IncreaseScore (500);
				audio.pitch = 2 - health / 100.00f;
				audio.PlayOneShot (hit);
			} else {
				ScoreSystem.MessageManager.SetMessage ("Hull Breached", 5);
				ScoreSystem.IncreaseScore (5000);
				ScoreSystem.Ball = ScoreSystem.Ball + 1;
				audio.pitch = 2;
				audio.PlayOneShot (hit);
				audio.pitch = 1;
				audio.PlayOneShot (down);
			}
		}
	}
}
