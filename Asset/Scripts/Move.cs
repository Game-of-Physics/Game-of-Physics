using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public Vector3 iniVel = new Vector3(0,0,0);
    public Vector3 vel = new Vector3(0,0,0);
    public Vector3 acc = new Vector3(0,0,0);
    public void Accelarate (float force) {
        acc.x = force/GetComponent<Rigidbody>().mass;
    }

    public void velocity (float v) {
        iniVel.x = v;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vel = iniVel + acc*Time.deltaTime;
        transform.position = transform.position + vel*Time.deltaTime;
    }
}
