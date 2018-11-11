using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    // How a detector communicates with this behavior
    public abstract void Activate();
    public abstract void Activate(bool args);
    public abstract void Activate(int args);
}
