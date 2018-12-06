using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject Active;

    public GameObject InActive;

    public bool Reversible;

    public bool State { get; private set; }

    private ActivatorGroup group;

    private Collider col;

    // Use this for initialization
    void Awake () {
        Active.SetActive(State);
        InActive.SetActive(!State);
        col = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGroup(ActivatorGroup group)
    {
        this.group = group;
    }

    public void HardReset()
    {
        State = false;
        Active.SetActive(State);
        InActive.SetActive(!State);
        Debug.Log("Reset");
        col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (group.State == Objective.ObjectiveState.Enabled && other.gameObject.tag == "Ball")
        {
            Hit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (group.State == Objective.ObjectiveState.Enabled && collision.gameObject.tag == "Ball")
        {
            Hit();
        }
    }

    private void Hit()
    {
        State = Reversible ? !State : true;
        Active.SetActive(State);
        InActive.SetActive(!State);
        group.Alert();
        col.enabled = State ? Reversible : true;
    }
}
