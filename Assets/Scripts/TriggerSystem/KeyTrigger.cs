using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : Detector {

    public KeyCode Key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Activate(Input.GetKey(Key));
	}
}
