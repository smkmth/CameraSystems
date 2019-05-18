using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health =100;
    public bool hitFlashing = false;

    public float attackDamage =10;
    public float attackRange =1;

    public void Hit(float damage)
    {
        health -= damage;
        if (!hitFlashing)
        {
            StopCoroutine(HitFlash());
            StartCoroutine(HitFlash());
        }
        
        if (health <= 0)
        {
            ShowDeathUI();
        }

    }

    public void ShowDeathUI()
    {
        Debug.Log("YOU DIED!");
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
   
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * attackRange, Color.red);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
            {
                hit.transform.gameObject.GetComponent<Enemy>().Hit(attackDamage);
            }
            
        }
    }

    IEnumerator HitFlash()
    {
        hitFlashing = true;
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        hitFlashing = false;

    }

}
