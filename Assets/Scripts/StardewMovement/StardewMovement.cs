using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardewMovement : MonoBehaviour
{
  
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        float rawHozMovement = Input.GetAxisRaw("Horizontal");
        float rawVertMovement = Input.GetAxisRaw("Vertical");

        //Tank controls :
        /*
        transform.Translate(Vector3.forward * vertMovement * Time.deltaTime * speed);

        if (hozMovement > 0)
        {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
        if (hozMovement < 0)
        {
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }
        */

        //stardew controls

        Vector3 movement = new Vector3(rawHozMovement, 0.0f, rawVertMovement);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);

        }


        transform.Translate(movement * speed * Time.deltaTime, Space.World);



    }
}
