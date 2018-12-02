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
        if (!released)
        {
            rigid.MovePosition(Vector3.MoveTowards(transform.position, BackPos.position, Time.fixedDeltaTime * PullSpeed));
            high = transform.position;
        }
        else
        {
            lerp -= Time.fixedDeltaTime / ReleasePeriod;
            if (lerp < 0)
            {
                lerp = 0;
            }
            rigid.MovePosition(Vector3.Lerp(RestPos.position, high, lerp));
        }
    }

    public override void Activate()
    {
        if (lerp == 0 || lerp == 1)
        {
            lerp = 1;
            released = false;
            high = transform.position;
            // Confuse Unity so that it does physics right
            gameObject.SetActive(false);
            gameObject.SetActive(true);
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
