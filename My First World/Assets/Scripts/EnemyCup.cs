using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCup : MonoBehaviour
{
    private Rigidbody2D cupBody;
    public float movespeed;
    public float jumpforce;

    private bool facingRight = true;
    public Transform Groundcheck;
    public Transform Wallcheck;


    //for checking if slime is at the edge or hitting a wall, know when to turn back
    //RaycastHit2D hit;
    //RaycastHit2D hit2;
    public LayerMask groundlayers;

    //for checking if cup is knockback

    public float knockbacktimer;
    private float timer;
    public bool knockBack;

    //for cooldown for jumping
    public float jumpcooldown;
    private float jumptimer;
    //public bool isintheair;
    
    void Start()
    {
        cupBody = GetComponent<Rigidbody2D>();
        timer = knockbacktimer;
        jumptimer = jumpcooldown;
        //Groundcheck = GetComponentInChildren<Transform>();
    }
    private void Update()
    {
        //hit = Physics2D.Raycast(Groundcheck.position, -transform.up, 0.3f, groundlayers);
        //hit2 = Physics2D.Raycast(Wallcheck.position, transform.right, 0.3f, groundlayers);
        

        if (knockBack == false)
        {
            
            if (isgroundedatedge() == true)
            {
                if (isgrounded() == true)
                {
                    //isintheair = true;
                    if (facingRight == true)
                    {

                        if (jumptimer > 0)
                        {

                            jumptimer -= Time.deltaTime;

                        }
                        else
                        {
                            jumptimer = jumpcooldown;
                            jumpright();
                        }
                    }
                    else
                    {

                        if (jumptimer > 0)
                        {

                            jumptimer -= Time.deltaTime;

                        }
                        else
                        {
                            jumptimer = jumpcooldown;
                            jumpleft();
                        }
                    }
                }
                
            }
            else
            {
                if (isintheair() == false)
                {
                    facingRight = !facingRight;
                    transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
                }
            }
        }
        else
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else //if (timer <= 0)
            {
                timer = knockbacktimer;
                knockBack = false;
            }
        }

    }
    private void jumpright()
    {
        cupBody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        cupBody.AddForce(transform.right * movespeed, ForceMode2D.Impulse);
    }
    private void jumpleft()
    {
        cupBody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        cupBody.AddForce(-transform.right * movespeed, ForceMode2D.Impulse);
    }
    public bool isgroundedatedge()
    {
        if (Physics2D.Raycast(Groundcheck.position, -transform.up, 0.3f, groundlayers) == true)
        {
            return true;
        }
        else return false;
    }
    public bool isgrounded()
    {
        if (Physics2D.Raycast(Groundcheck.position, -transform.up, 0.3f, groundlayers) == true)
        {
            return true;
        }
        else return false;
    }
    public bool isintheair()
    {
        if (isgrounded() == true)
        {
            return false;
        }
        else return true;
    }




}
