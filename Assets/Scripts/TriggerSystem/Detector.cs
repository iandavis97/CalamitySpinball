using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    // The behaviors this detector communicates with
    public List<Behavior> Connected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Protocol for activation
    public void Activate()
    {
        for (int i = 0; i < Connected.Count; i++)
        {
            Connected[i].Activate();
        }
    }
    public void Activate(bool args)
    {
        for (int i = 0; i < Connected.Count; i++)
        {
            Connected[i].Activate(args);
        }
    }
    public void Activate(int args)
    {
        for (int i = 0; i < Connected.Count; i++)
        {
            Connected[i].Activate(args);
        }
    }
}
