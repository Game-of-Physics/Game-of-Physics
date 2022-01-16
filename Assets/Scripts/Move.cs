using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public Rigidbody ball;
    public Camera ca;
    private Ray ra;  
    private RaycastHit hit;  
    private int flag = 0;
    private int flag0 = 0;
    public GameObject direc;
    public GameObject direc0;
    public float theta;
    public float phi;
    public float force;
    public KeyCode m_upkey = KeyCode.UpArrow;
    public KeyCode m_downkey = KeyCode.DownArrow;
    public KeyCode m_rightkey = KeyCode.RightArrow;
    public KeyCode m_leftkey = KeyCode.LeftArrow;
    // public LayerMask layerMask;

    public void Accelarate () {
        ball.AddForce(force*Mathf.Cos(phi*Mathf.PI/180)*Mathf.Sin(theta*Mathf.PI/180),force*Mathf.Cos(theta*Mathf.PI/180),force*Mathf.Sin(phi*Mathf.PI/180)*Mathf.Sin(theta*Mathf.PI/180));
    }

    public void MoveWithMouse () {
        if (Input.GetMouseButtonDown(0))  
        {  
            int layerMask = (1 << 3);
            ra = ca.ScreenPointToRay(Input.mousePosition);  
            if (Physics.Raycast(ra, out hit, Mathf.Infinity, layerMask))  
            {  
               if (flag == 0)  
                {  
                    flag = 1;  
                } else  
                {  
                    flag = 0;  
                }  
            }  
        }
    }

    public void DirectionGuide () {
        direc0.SetActive(true);
        direc0.transform.position = this.transform.position;
        direc.transform.rotation = Quaternion.Euler(0,-phi,-theta);
        direc0.transform.localScale = new Vector3 (1f + force*0.125f, 1f + force*0.125f, 1f + force*0.125f);
    }
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        theta = 0;
        phi = 0;
        direc0.SetActive(false);
        force = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(m_upkey)) {
            theta = theta - Time.deltaTime*100;
            flag0 = 1;
        }
        if (Input.GetKey(m_downkey)) {
            theta = theta + Time.deltaTime*100;
            flag0 = 1;
        }
        if (Input.GetKey(m_rightkey)) {
            phi = phi + Time.deltaTime*100;
            flag0 = 1;
        }
        if (Input.GetKey(m_leftkey)) {
            phi = phi - Time.deltaTime*100;
            flag0 = 1;
        }
        if (Input.GetKey(KeyCode.I)) {
            force = force + Time.deltaTime*20;
            force = Mathf.Min(force, 10);
            flag0 = 1;
        }
        if (Input.GetKey(KeyCode.J)) {
            force = force - Time.deltaTime*20;
            force = Mathf.Max(force, 0);
            flag0 = 1;
        }
        if (flag0 == 1 || (Input.GetKey(KeyCode.Space))) {
            DirectionGuide();
            if (Input.GetKey(KeyCode.Space)) {
                Accelarate ();
            }
        }
        else {
            direc0.SetActive(false);
        }
        flag0 = 0;
        // MoveWithMouse();
        // if (flag == 1) {
        //     Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - ca.transform.position.z);
        //     transform.position = ca.ScreenToWorldPoint(m_MousePos);
        //     ball.velocity = new Vector3(0,0,0);
        // }
    }
}
