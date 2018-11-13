﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : Behavior {

    public Transform RestPos;
    public Transform PlayPos;
    public float DownPeriod = 1;
    public float UpPeriod = 1;

    private float lerp;
    private bool active;
    private Rigidbody rigid;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        transform.rotation = RestPos.rotation;
	}

    // Update is called once per frame
    void LateUpdate() {
        if (active)
        {
            lerp += Time.deltaTime / UpPeriod;
            if (lerp > 1)
            {
                lerp = 1;
                active = false;
            }
        }
        else
        {
            lerp -= Time.deltaTime / DownPeriod;
            if (lerp < 0)
            {
                lerp = 0;
            }
        }
        rigid.MoveRotation(Quaternion.Slerp(RestPos.rotation, PlayPos.rotation, lerp));
	}

    public override void Activate()
    {
        active = true;
    }

    public override void Activate(bool args)
    {
        active = args;
    }

    public override void Activate(int args)
    {
        Activate(args != 0);
    }

}
