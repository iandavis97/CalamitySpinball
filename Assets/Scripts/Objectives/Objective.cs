using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : MonoBehaviour {

    public enum ObjectiveState
    {
        Locked,
        Enabled,
        JustFinished,
        Finished
    }

    // Links 
    // Don't change these at runtime
    public List<Objective> PreReqs;
    private List<Objective> dependants;

    public ObjectiveState State { get; private set; }

    public float FinishSpan = .5f;

    public int Score;
    public float ScoreMultiplier = 1;
    public int MultiplierPeriod = -1;

    public string OnAvailable;
    public string OnComplete;
    public float AvailMessageTimer;

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
        State = ObjectiveState.JustFinished;
        OnStateChange();
        if (OnComplete != "" && FinishSpan > 0 && ScoreSystem.MessageManager != null)
        {
            ScoreSystem.MessageManager.SetMessage(OnComplete, FinishSpan);
        }
        StartCoroutine(DeferFinish());
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
        if(State == ObjectiveState.Enabled && OnAvailable != "" && ScoreSystem.MessageManager != null)
        {
            ScoreSystem.MessageManager.SetMessage(OnAvailable, AvailMessageTimer);
        }
        OnStateChange();
    }

    // Called by end points to reset the objectives
    private void ResetObjectiveHierarchy()
    {
        if(PreReqs.Count > 0)
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
        OnStateChange();
        OnReset();
    }

    private IEnumerator DeferFinish()
    {
        yield return new WaitForSeconds(FinishSpan);
        ScoreSystem.IncreaseScore(Score);
        if (MultiplierPeriod > 0)
        {
            ScoreSystem.SetMultiplier(ScoreMultiplier, MultiplierPeriod);
        }
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

    protected abstract void OnStateChange();
    protected abstract void OnReset();
}
