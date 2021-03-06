﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHold : Detector {

    public int scoreToAdd;//increase score by this amt when ball released

    // Time for which the ball is held
    public float HoldPeriod = -1;

    // Position the ball is held at
    public Transform HoldPosition;

    // Velocity the ball is released with
    public Transform ReleaseAim;

    public float ReleaseSpeed;

    // The held ball's rigidbody
    private Rigidbody held;
    public bool Holding { get { return held != null; } }

    // The release timer
    private float timer;

    // is release velocity random?
    [SerializeField]
    bool isVelRandom = false;
    // if velocity is random, what is its max magnitude
    [SerializeField]
    float randomVelMagnitude;
    [SerializeField]
    AudioClip capture;
    [SerializeField]
    AudioClip release;
    AudioSource source;
	// Use this for initialization
	void Start () {
        // Default transform is the one on the object
		if(HoldPosition == null)
        {
            HoldPosition = transform;
        }
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(held != null)
        {
            held.transform.position = Vector3.MoveTowards(held.position, HoldPosition.position, 5 * Time.deltaTime);
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    Release();
                }
            }
        }
	}

    // Look for balls to lock
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball" && this.isActiveAndEnabled && !Holding)
        {
            held = other.GetComponent<Rigidbody>();
            held.isKinematic = true;
            held.velocity = Vector3.zero;
            timer = HoldPeriod;
            Activate(true);
            source.clip = capture;
            source.Play();
        }
    }

    // Releases the ball
    public void Release()
    {
        // play releasing sound
        source.Stop();
        source.clip = release;
        source.Play();
        if(!Holding)
        {
            return;
        }
        held.isKinematic = false;
        if (!isVelRandom)
        {
            //held.velocity = ReleaseVelocity;
            held.velocity = (ReleaseAim.position - transform.position).normalized * ReleaseSpeed;
        }
        else
        {
            Vector3 randomVel = new Vector3();
            randomVel += transform.right * Random.Range(-1.0f, 1.0f);
            randomVel += transform.forward * Random.Range(-1.0f, 1.0f);
            randomVel.Normalize();
            randomVel *= randomVelMagnitude;
            held.velocity = randomVel;
        }
        held = null;

        ScoreSystem.IncreaseScore(scoreToAdd);
    }

}
