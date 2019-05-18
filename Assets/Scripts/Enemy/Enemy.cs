using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 4.0f;
    public float maxDist = 10;
    public float minDist = 5;
    public float attackTime = 1.0f;
    public float recoverTime = 2.0f;
    public float attackRange = 1.0f;
    public float health = 10;


    public float attackDamage = 1.0f;

    private bool attacking =false;
    private bool hitFlashing = false;
    public Color AttackColor = Color.red; 
    public Color NeutralColor = Color.white; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= maxDist)
        {
            if (!attacking)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }

            if (Vector3.Distance(transform.position, player.position) <= minDist)
            {
                if (!attacking)
                {
                    StopCoroutine(Attack());
                    StartCoroutine(Attack());

                }

            }
        }


    }

    public IEnumerator Attack()
    {
        attacking = true;
        GetComponent<Renderer>().material.color = AttackColor;
        yield return new WaitForSeconds(attackTime);

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * attackRange, Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            hit.transform.gameObject.GetComponent<Player>().Hit(attackDamage);
        }
        GetComponent<Renderer>().material.color = NeutralColor;
        yield return new WaitForSeconds(recoverTime);

        attacking = false;
        yield return null;
    }


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
            Destroy(gameObject);
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

