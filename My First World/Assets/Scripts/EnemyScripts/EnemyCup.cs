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
    public Transform MediumGroundcheck;


    //for checking if slime is at the edge or hitting a wall, know when to turn back
    //RaycastHit2D hit;
    //RaycastHit2D hit2;
    public LayerMask groundlayers;
    public LayerMask enemylayers;

    //for checking if cup is knockback

    public float knockbacktimer;
    private float timer;
    public bool knockBack;

    //for cooldown for jumping
    public float jumpcooldown;
    private float jumptimer;
    //public bool isintheair;

    //for groundcheck boxcast
    public Vector2 boxsize; // for the size of the box to be use in boxcasting
    public float castdistance; //for the cast distance from the centre position of the gameobject 

    

    //animator
    private Animator m_Animator;
    void Start()
    {
        cupBody = GetComponent<Rigidbody2D>();
        timer = knockbacktimer;
        jumptimer = jumpcooldown;
        Physics2D.IgnoreLayerCollision(10, 10, true);
        m_Animator = GetComponent<Animator>();
        //Groundcheck = GetComponentInChildren<Transform>();
    }
    private void Update()
    {
        m_Animator.SetFloat("VelocityY", cupBody.velocity.y);
        if(isgroundedattheedge() == true || isgroundedatthecentre() ==true)
        {
            m_Animator.SetBool("Landed", true);
        }
        else m_Animator.SetBool("Landed", false);
        if (knockBack == false)
        {
            
            if (isgroundedatthecentre() == true)
            {
                if (isgroundedattheedge() == true && wallcheck() ==false /*&& enemycheck() == false*/)
                {

                    if (facingRight == true)
                    {

                        if (jumptimer > 0)
                        {

                            jumptimer -= Time.deltaTime;

                        }
                        else
                        {
                            jumptimer = jumpcooldown;
                            m_Animator.SetTrigger("ChargingUp");
                            //jumpright();
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
                            m_Animator.SetTrigger("ChargingUp");
                            //jumpleft();
                        }
                    }

                }
                else
                {
                    if (isgroundedatthecentre() == true)
                    {
                        facingRight = !facingRight;
                        transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
                    }
                }
            }
           
        }
        else
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                m_Animator.SetBool("GotHit", true);
            }
            else //if (timer <= 0)
            {
                timer = knockbacktimer;
                knockBack = false;
                m_Animator.SetBool("GotHit", false);
            }
        }

    }
    private void jump()
    {
        
        
            if (facingRight == true)
            {
                jumpright();
            }
            else
            {
                jumpleft();
            }
            
        
    }
    private void jumpright()
    {
        //cupBody.velocity = new Vector2(0, 0);
        cupBody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        cupBody.AddForce(transform.right * movespeed, ForceMode2D.Impulse);
    }
    private void jumpleft()
    {
        //cupBody.velocity = new Vector2(0, 0);
        cupBody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        cupBody.AddForce(-transform.right * movespeed, ForceMode2D.Impulse);
    }
    public bool isgroundedattheedge()
    {
        if (Physics2D.Raycast(Groundcheck.position, -transform.up, 0.3f, groundlayers) == true)
        {
            return true;
        }
        else return false;
    }
    public bool isgroundedatthecentre()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castdistance, groundlayers))
        {
            /*canjump = true;*/
            return true;
        }
        else
        {
            /*canjump = false;*/
            return false;
        }
    }
    /*public void OnDrawGizmos() // to visualize groundcheck/isgrounded
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castdistance, boxsize);
    }*/

    public bool wallcheck()
    {
        if (Physics2D.Raycast(Wallcheck.position, transform.right, 0.2f, groundlayers) == true)
        {
            return true;
        }
        else return false;
    }
/*    public bool enemycheck()
    {
        if (Physics2D.Raycast(Wallcheck.position, transform.right, 0.05f, enemylayers) == true)
        {
            return true;
        }
        else return false;
    }*/
    






}
