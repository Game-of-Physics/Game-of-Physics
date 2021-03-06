using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform Role;
    private Vector3 offset = new Vector3(20,0,50);
    private float offsetY = 0;

    public void CameraFOV()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 2000;
        if (Input.GetMouseButton(1)) {
            offsetY = Input.GetAxis("Mouse Y")* Time.deltaTime * 200;
        }
        offset = offset + Vector3.forward * wheel + Vector3.down*offsetY;
        offset.y = Mathf.Min(Mathf.Max(offset.y, -10), 10);
        offset.z = Mathf.Min(Mathf.Max(offset.z, 30), 100);
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = Role.position - this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraFOV();
        // this.transform.position = Role.position - offset;
        this.transform.position = new Vector3 ( Role.position.x - offset.x, Role.position.y - offset.y, Mathf.Lerp(this.transform.position.z, (Role.position - offset).z, 0.5f));
    }
}
