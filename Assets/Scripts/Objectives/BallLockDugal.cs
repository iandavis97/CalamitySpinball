using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLockDugal : Objective {

    public BallManager Manager;

    public Gate Barrier;

    public List<BallHold> slots;

    private int filled;
	
	// Update is called once per frame
	void Update () {
        if(State == ObjectiveState.Enabled)
        {
            if (slots[filled].Holding)
            {
                Manager.AddBall();
                filled++;
                if (filled >= slots.Count)
                {
                    Finish();
                }
                else
                {
                    slots[filled].enabled = true;
                }
            }
        }    
	}

    protected override void OnReset()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Release();
            filled = 0;
            slots[i].enabled = false;
        }
        Barrier.Set(true);
        StartCoroutine(DelayReset());
    }

    protected override void OnStateChange()
    {
        switch (State)
        {
            default:
            case ObjectiveState.Locked:
                Barrier.Set(false);
                for (int i = 0; i < slots.Count; i++)
                {
                    slots[i].enabled = false;
                }
                break;
            case ObjectiveState.Enabled:
                Barrier.Set(true);
                filled = 0;
                slots[0].enabled = true;
                for (int i = 1; i < slots.Count; i++)
                {
                    slots[i].enabled = false;
                }
                break;
            case ObjectiveState.Finished:
            case ObjectiveState.JustFinished:
                Barrier.Set(false);
                break;
        }
    }

    private IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(10);
        OnStateChange();
    }
}
