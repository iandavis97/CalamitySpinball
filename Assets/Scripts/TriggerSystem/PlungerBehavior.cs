using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerBehavior : Behavior {

    public Transform RestPos;
    public Transform BackPos;
    public float ReleasePeriod = 1;
    public float PullSpeed = 1;

    private Vector3 high;
    private float lerp;
    private Rigidbody rigid;
    private bool released;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        transform.position = RestPos.position;
	}

    // Update is called once per frame
    void FixedUpdate() {
        rigid.velocity = Vector3.zero;
        if (!released)
        {
            if (Vector3.Dot(BackPos.position - transform.position, BackPos.position - RestPos.position) > 0)
            {
                float speed = (BackPos.position - transform.position).magnitude;
                speed = speed > PullSpeed ? PullSpeed : speed;
                rigid.velocity = (BackPos.position - transform.position).normalized * PullSpeed;
                high = transform.position;
            }
        }
        else
        {
            lerp -= Time.fixedDeltaTime / ReleasePeriod;
            if (lerp < 0)
            {
                lerp = 0;
            }
            else
            {
                rigid.velocity = (RestPos.position - high) / ReleasePeriod;
            }
        }
    }

    public void MovePos()
    {

    }

    public override void Activate()
    {
        if (lerp == 0 || lerp == 1)
        {
            lerp = 1;
            released = false;
            high = transform.position;
        }
    }

    public override void Activate(bool args)
    {
        released = !args;
        if(args)
        {
            Activate();
        }
    }

    public override void Activate(int args)
    {
        Activate(args != 0);
    }
}
