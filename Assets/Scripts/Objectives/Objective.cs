using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : MonoBehaviour {

    public enum ObjectiveState
    {
        Locked,
        Enabled,
        Finished
    }

    // Links 
    // Don't change these at runtime
    public List<Objective> PreReqs;
    private List<Objective> dependants;

    public ObjectiveState State { get; private set; }

    private void Awake()
    {
        dependants = new List<Objective>();
    }

    // Use this for initialization
    protected virtual void Start ()
    {
        State = PreReqs.Count > 0 ? ObjectiveState.Locked : ObjectiveState.Enabled;
        for (int i = 0; i < PreReqs.Count; i++)
        {
            PreReqs[i].dependants.Add(this);
        }
        OnStateChange();
    }

    // Declares the objective as complete to its dependants
    protected void Finish()
    {
        if (dependants.Count > 0)
        {
            State = ObjectiveState.Finished;
            for (int i = 0; i < dependants.Count; i++)
            {
                dependants[i].CheckPreReqs();
            }
        }
        else
        {
            ResetObjectiveHierarchy();
        }
        OnStateChange();
    }

    // Check if prereqs are met
    private void CheckPreReqs()
    {
        State = ObjectiveState.Enabled;
        for (int i = 0; i < PreReqs.Count; i++)
        {
            if(PreReqs[i].State != ObjectiveState.Finished)
            {
                State = ObjectiveState.Locked;
            }
        }
        OnStateChange();
    }

    // Called by end points to reset the objectives
    private void ResetObjectiveHierarchy()
    {
        if(PreReqs.Count < 0)
        {
            for (int i = 0; i < PreReqs.Count; i++)
            {
                PreReqs[i].ResetObjectiveHierarchy();
            }
            State = ObjectiveState.Locked;
        }
        else
        {
            State = ObjectiveState.Enabled;
        }
    }

    protected abstract void OnStateChange();
}
