using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingObjective : Objective {

    

    protected override void OnReset()
    {

    }

    protected override void OnStateChange()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody vel = other.GetComponent<Rigidbody>();
        if (State == ObjectiveState.Enabled && other.gameObject.tag == "Ball" && vel != null && Vector3.Dot(vel.velocity, transform.forward) > 0)
        {
            Finish();
        }
    }
}
