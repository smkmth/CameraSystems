using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRotation : MonoBehaviour
{
    public float StartRotateSpeed;
    public float MaxRotateSpeed;
    public float Step;
    public bool usingMouse;
    

    private float rot;

    // Start is called before the first frame update

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       if (usingMouse)
        {
            if (Input.GetAxis("Mouse X") != 0)
            {
                rot = Mathf.Lerp(StartRotateSpeed, MaxRotateSpeed, Step * Time.deltaTime);
            }

            Debug.Log(Input.GetAxis("RightStickHorizontal"));
            transform.Rotate(0, rot * Input.GetAxis("Mouse X"), 0);

        }
        else
        {

            //Vector3 lookDirection = new Vector3(Input.GetAxis("RightStickHorizontal"), 0, Input.GetAxis("RightStickVertical"));

            float RsHorizontal = Input.GetAxis("RightStickHorizontal");
            float RsVertical = Input.GetAxis("RightStickVertical");
            Vector3 lookDirection = new Vector3(RsVertical, 0.0f, RsHorizontal);

            transform.rotation = Quaternion.Euler(lookDirection);
            transform.LookAt(transform.position + lookDirection, Vector3.up);

        }
       

    }
}
