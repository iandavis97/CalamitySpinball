using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour 
{
	[SerializeField]
	GameObject ball;
    public GameObject GetBall() { return ball; }
    public void SetBall(GameObject g1) { ball = g1; }
	Rigidbody rb;
	float forceMagnitude = 0;
    AudioSource sound;
    public float GetForceMagnitude()
    {
        return forceMagnitude;
    }
    public void SetForceMagnitude(float x)
    {
        forceMagnitude = x;
    }
    // Use this for initialization
    void Start () 
	{
		rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.DownArrow))
		{
			forceMagnitude += .5f;
		}
        if (Input.GetKeyUp(KeyCode.DownArrow) && (forceMagnitude != 0.0f))
        {
            ball.GetComponent<Rigidbody>().AddForce(Vector3.up * forceMagnitude);
            if (sound.isPlaying == false)
                sound.Play();
        }
	}
}
