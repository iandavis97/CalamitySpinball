using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject Active;

    public GameObject InActive;

    public bool Reversible;

    public bool UseMaterials;
    public Material UnLit;
    public Material Lit;

    public bool State { get; private set; }

    public float FlashPeriod = .1f;
    private float timer;

    private ActivatorGroup group;

    private Collider col;

    // Use this for initialization
    void Awake () {
        col = GetComponent<Collider>();
        HardReset();
    }
	
	// Update is called once per frame
	void Update () {
		if(group.State == Objective.ObjectiveState.JustFinished)
        {
            timer = (timer + FlashPeriod - Time.deltaTime) % FlashPeriod;
            bool on = timer < FlashPeriod / 2;
            Active.GetComponent<Renderer>().material = on ? Lit : UnLit;
        }
    }

    public void SetGroup(ActivatorGroup group)
    {
        this.group = group;
    }

    public void HardReset()
    {
        State = false;
        if (!UseMaterials)
        {
            Active.SetActive(State);
            InActive.SetActive(!State);
        }
        Active.GetComponent<Renderer>().material = State ? Lit : UnLit;
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
        if (!UseMaterials)
        {
            Active.SetActive(State);
            InActive.SetActive(!State);
        }
        else
        {
            Active.GetComponent<Renderer>().material = State ? Lit : UnLit;
        }
        group.Alert();
        col.enabled = State ? Reversible : true;
    }
}
