using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour {
    
    public List<Renderer> Arrows;
    public Material UnLit;
    public Material Lit;
    public float Period;

    public PassingObjective Track;

    private float timer;
    private Objective.ObjectiveState lastState;

	// Update is called once per frame
	void Update () {
        if(lastState != Track.State)
        {
            Refresh();
        }
        if(lastState == Objective.ObjectiveState.Enabled && Arrows.Count != 0)
        {
            timer = (timer + Period - Time.deltaTime) % Period;
            int index = (int)(timer / (Period / Arrows.Count));
            Arrows[index].material = Lit;
            Arrows[(index + 1) % Arrows.Count].material = UnLit;
        }
        else if(lastState == Objective.ObjectiveState.JustFinished && Arrows.Count != 0)
        {
            timer = (timer + (Period / Arrows.Count) - Time.deltaTime) % (Period / Arrows.Count);
            bool on = timer < (Period / Arrows.Count) / 2;
            for (int i = 0; i < Arrows.Count; i++)
            {
                Arrows[i].material = on ? Lit : UnLit;
            }
        }
    }

    public void Refresh()
    {
        timer = Period;
        switch (Track.State)
        {
            case Objective.ObjectiveState.Enabled:
            case Objective.ObjectiveState.Locked:
            case Objective.ObjectiveState.JustFinished:
                for (int i = 0; i < Arrows.Count; i++)
                {
                    Arrows[i].material = UnLit;
                }
                break;
            case Objective.ObjectiveState.Finished:
                for (int i = 0; i < Arrows.Count; i++)
                {
                    Arrows[i].material = Lit;
                }
                break;
            default:
                break;
        }
        lastState = Track.State;
    }
}
