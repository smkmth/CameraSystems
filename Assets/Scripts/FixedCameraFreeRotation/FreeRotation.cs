﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRotation : MonoBehaviour
{
    public float StartRotateSpeed;
    public float MaxRotateSpeed;
    public float Step;

    

    private float rot;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetAxis("Mouse X") != 0)
        {
            rot = Mathf.Lerp(StartRotateSpeed, MaxRotateSpeed, Step * Time.deltaTime);
        }
       

        transform.Rotate(0, rot * Input.GetAxis("Mouse X"), 0);
    }
}