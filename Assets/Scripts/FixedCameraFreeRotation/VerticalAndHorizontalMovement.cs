using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAndHorizontalMovement : MonoBehaviour
{



    public float MovementSpeed;
    private Vector3 movepos;

    private float currentMoveSpeed;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {

            transform.position += movepos + transform.forward * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            
            transform.position += movepos + transform.right * Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;

        }



    }
}
