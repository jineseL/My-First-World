using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossScript : MonoBehaviour
{
    private Rigidbody2D cupBody;
    /*public float movespeed;
    public float jumpforce;*/

    //private bool facingRight = true;
    //public Transform Groundcheck;
    //public Transform Wallcheck;
    //public Transform MediumGroundcheck;


    //for checking if slime is at the edge or hitting a wall, know when to turn back
    //RaycastHit2D hit;
    //RaycastHit2D hit2;
    public LayerMask groundlayers;
    //public LayerMask enemylayers;

    //for checking if cup is knockback

    /*public float knockbacktimer;
    private float timer;
    public bool knockBack;*/

    //for cooldown for jumping
    public float jumpcooldown;
    private float jumptimer;
    //public bool isintheair;

    //for groundcheck boxcast
    public Vector2 boxsize; // for the size of the box to be use in boxcasting
    public float castdistance; //for the cast distance from the centre position of the gameobject 

    //for FML 
    private GameObject player;
    public bool JumpingUp;
    public float speed;
    public float distanceabove;
    private float slamcounter;
    public float slamdelaytimer;
    public float slamspeed;
    private bool slamdown;
    private float movinguptimer;
    public float movingupduration;

    public HealthBarScript healthbar;

    //slam fire
    /*public GameObject fireleft;
    public GameObject fireRight;*/

    private float starttimer;
    private float startupgravity = 2;
    //animator
    private Animator m_Animator;
    void Start()
    {
        player = GameObject.Find("Player");
        cupBody = GetComponent<Rigidbody2D>();
        /*timer = knockbacktimer;*/
        jumptimer = jumpcooldown;
        Physics2D.IgnoreLayerCollision(10, 10, true);
        m_Animator = GetComponent<Animator>();
        JumpingUp = false;
        slamdown = false;
        healthbar.SetMaxHealth(gameObject.GetComponent<EnemyBehaviour>().health);
        //Groundcheck = GetComponentInChildren<Transform>();
    }
    private void Update()
    {
        //starting gravity to make fking cup drop
        if (starttimer < startupgravity)
        {
            starttimer += Time.deltaTime;
            cupBody.gravityScale = 1;
        }
        else
        {
            cupBody.gravityScale = 0;
        }
        if ( isgroundedatthecentre() == true)
        {
            m_Animator.SetBool("Landed", true);
        }
        else m_Animator.SetBool("Landed", false);

        /*if (knockBack == false)
        {*/

            if (isgroundedatthecentre() == true)
            {
                        if (jumptimer > 0)
                        {
                            jumptimer -= Time.deltaTime;
                        }
                        else
                        {
                            jumptimer = jumpcooldown;
                    turntowardsPlayer();
                    m_Animator.SetTrigger("ChargingUp");
                        }    
            }
        if (JumpingUp == true /*&& movinguptimer < movingupduration*/)
        {
            m_Animator.SetBool("GoingUp",true);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, distanceabove, player.transform.position.z), step);
            if (movinguptimer < movingupduration)
            {
                movinguptimer += Time.deltaTime;
            }
            
        }
        if(transform.position.y >= distanceabove-0.1f || movinguptimer >= movingupduration)
        {
            JumpingUp = false;
            
            if (slamcounter < slamdelaytimer)
            {
                slamcounter += Time.deltaTime;
            }
            else
            {
                m_Animator.SetBool("GoingUp", false);
                slamcounter = 0;
                slamdown = true;
                movinguptimer = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (slamdown == true)
        {
            if (isgroundedatthecentre() == false)
            {
                m_Animator.SetBool("GoingDown", true);
                cupBody.velocity = -transform.up * slamspeed;
            }
            if(isgroundedatthecentre() == true)
            {

                m_Animator.SetBool("GoingDown", false);
                slamdown = false;

            }
        }
    }
    private void jump()
    {
        JumpingUp = true;
        
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

    private void turntowardsPlayer()
    {
        if (transform.localScale.x >0)
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            
        }
        else if (transform.localScale.x <0)
        {
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            
        }

    }

}
