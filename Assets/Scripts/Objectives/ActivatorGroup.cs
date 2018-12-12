using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorGroup : Objective {

    public List<Activator> Children;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        for (int i = 0; i < Children.Count; i++)
        {
            Children[i].SetGroup(this);
        }
	}
	
    public void Alert()
    {
        if(State == ObjectiveState.Enabled)
        {
            bool live = true;
            for (int i = 0; i < Children.Count; i++)
            {
                if(!Children[i].State)
                {
                    live = false;
                    break;
                }
            }
            if(live)
            {
                Finish();
            }
        }
    }

    protected override void OnStateChange()
    {
        
    }

    protected override void OnReset()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            Children[i].HardReset();
        }
    }
}
