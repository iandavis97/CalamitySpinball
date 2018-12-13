using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLighting : MonoBehaviour {

	public Sprite litSprite;
	public Sprite unlitSprite;

	public bool lit = false;

	SpriteRenderer renderer;
	Light light;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer>();
		light = gameObject.GetComponent<Light> ();
		audio = gameObject.GetComponent<AudioSource> ();
		SetLit (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Ball") {
			Switch ();

			if (lit) {
				this.audio.pitch = 2.0f;
				this.audio.Play ();
				ScoreSystem.IncreaseScore(100);
			}
			else{
				this.audio.pitch = 1.0f;
				this.audio.Play ();
			}

		}

	}

	void Switch() {
		if (StarManager.changeAllowed)
			SetLit (!lit);
		else if (lit) {
			ScoreSystem.IncreaseScore (400);
			this.audio.Play ();
		}
	}

	public void SetLit(bool l){
		lit = l;

		if (lit) {
			this.renderer.sprite = litSprite;
			light.enabled = true;
		} else {
			this.renderer.sprite = unlitSprite;
			light.enabled = false;
		}
	}
}
