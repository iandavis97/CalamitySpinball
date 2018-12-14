using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public Transform Open;

    public Transform Closed;

    public float Period = 1;

    public float lerp;
     
    public bool State { get; private set; }

	// Update is called once per frame
	void Update () {
        if (State)
        {
            lerp -= Time.deltaTime / Period;
            if(lerp < 0)
            {
                lerp = 0;
            }
        }
        else
        {
            lerp += Time.deltaTime / Period;
            if(lerp > 1)
            {
                lerp = 1;
            }
        }
        transform.position = Vector3.Lerp(Open.transform.position, Closed.transform.position, lerp);
	}

    public void Set(bool state)
    {
        State = state;
    }
}
