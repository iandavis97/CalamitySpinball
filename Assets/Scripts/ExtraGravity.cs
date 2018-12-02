using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraGravity : MonoBehaviour {

    public Vector3 Grav;

    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        rigid.velocity += (Grav * Time.deltaTime);
	}
}
