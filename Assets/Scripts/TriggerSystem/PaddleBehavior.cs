using System.Collections;
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
    void FixedUpdate() {
        if (active)
        {
            lerp += Time.fixedDeltaTime / UpPeriod;
            if (lerp > 1)
            {
                lerp = 1;
				rigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }
			else
				rigid.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
        else
        {
            lerp -= Time.fixedDeltaTime / DownPeriod;
            if (lerp < 0)
            {
                lerp = 0;
				rigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }
			else
				rigid.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
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
