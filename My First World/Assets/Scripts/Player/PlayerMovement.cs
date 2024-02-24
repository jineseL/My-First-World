using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    // for horizontal movement
    public static float movementspeed = 5; // original is 5 put 8 to test faster speed
    public float horizontalmovement;
    public static bool canmove;

    //for checking if character is facing right or left
    public bool isfacingright = true;
    private SpriteRenderer playersprite;

    //for jumping & groundcheck
    public float jumpheight;
    private float jumping;
    private bool spacecanbepress;
    private float jumptimer;
    private float jumpduration=0.3f;
    private bool falloffledgejump; //jumping after falling off a ledge
    private bool headbump; //player head hit ceiling
    public float castdistanceforheadbump;
    public Vector2 boxsizeforheadbump;

    //private bool canjump; //to prevent continous jumping
    public Vector2 boxsize; // for the size of the box to be use in boxcasting
    public float castdistance; //for the cast distance from the centre position of the gameobject 
    public LayerMask layer; // for the layer you want to detect, in this case will be all platform 
    public float gravity;

    //for double jumping
    public static bool canDoubleJump=true;
    public bool secondJump = false;

    //for wind effect
    public static bool windEffect; //to activate on the dialouge
    private bool windRight = true; //to switch the wind direction
    private enum windstate
    {
        windRight,
        windNeutral,
        windLeft,
    }
    private float windTimer = 0;
    public float windforce;
    public float windforceaddition;
    public float windforcewhenstandingstill;
    public float windDuration; // wind duration to blow at 1 direction
    windstate wind = windstate.windRight;
    //for alpha wind indicator should switch to partical effect after alpha
    public Image WindArrowLeft;
    public Image WindArrowDown;
    public Image WindArrowRight;

    private Animator animator;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playersprite = GetComponent<SpriteRenderer>();
        isfacingright = true;
        canmove = true;
        animator = GetComponent<Animator>();
        //windEffect = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //for horizontal movement
        animator.SetFloat("IsFalling", body.velocity.y);
            horizontalmovement = Input.GetAxis("Horizontal");
        animator.SetBool("GotHit", !canmove);
        if (body.velocity.y < -1)
        {
            animator.SetBool("IsJumping", false);
        }
        


        //if want to switch to GetAxisRaw
        /*if ((Input.GetKeyUp(KeyCode.A) == true || Input.GetKeyUp(KeyCode.D) == true) && isgrounded() == true) //to make character not bounce when going up slope
        {
            body.velocity = new Vector2(0, 0);
        }*/

        //Direction character is facing check n flipping player sprite
        if (PlayerHealth.timefreeze == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                isfacingright = false;
                playersprite.flipX = true;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                isfacingright = true;
                playersprite.flipX = false;
            }
            /*if (body.velocity.x < 0)
            {
                isfacingright = false;
                playersprite.flipX = true;
            }
            if (body.velocity.x > 0)
            {
                isfacingright = true;
                playersprite.flipX = false;
            }*/
        }


        //for jumping, controlling when to allow player to jump
        /*isgrounded = isgrounded();*/
        if (canmove)
        {
            if (canDoubleJump == false)
            {
                if (Input.GetButtonDown("Jump") == true && isgrounded() == true /*&& canjump ==true*/)
                {
                    animator.SetBool("IsJumping", true);
                    spacecanbepress = true;
                    /*canjump = false;*/
                    //body.velocity = new Vector2(body.velocity.x, jumpheight);
                    
                }
                
            }
            else//for double jumping
            {
                if (secondJump == false)
                {
                    if (Input.GetButtonDown("Jump") == true && isgrounded() == true && isheadbump()==false)
                    {
                        /*body.velocity = new Vector2(body.velocity.x, jumpheight);*/
                        animator.SetBool("IsJumping", true);
                        spacecanbepress = true;
                        secondJump = true;
                    }
                }
                else
                {
                    if (Input.GetButtonDown("Jump") && isheadbump() ==false)
                    {
                        animator.SetBool("IsJumping", true);
                        body.velocity = new Vector2(body.velocity.x, jumpheight);
                        secondJump = false;
                    }   
                }
                if (isgrounded() == true)
                {
                    falloffledgejump = true;
                }
                if (Input.GetButtonDown("Jump") && isgrounded() == false && falloffledgejump==true && isheadbump() ==false)
                {
                    animator.SetBool("IsJumping", true);
                    body.velocity = new Vector2(body.velocity.x, jumpheight);
                    falloffledgejump = false;  
                }
                
                
            }

        }
        if(spacecanbepress == true)//this is for hollow knight jumping effect
        {
            if (Input.GetButton("Jump") == true)
            {
                
                if (jumptimer < jumpduration && isheadbump() == false)
                {
                    jumptimer += Time.deltaTime;
                    body.velocity = new Vector2(body.velocity.x, jumpheight);
                }
                else
                {
                    animator.SetBool("IsJumping", false);
                    jumptimer = 0;
                    body.velocity = new Vector2(body.velocity.x, -0);
                    spacecanbepress = false;

                }
            }
            else
            {
                animator.SetBool("IsJumping", false);
                jumptimer = 0;
                body.velocity = new Vector2(body.velocity.x, -0);
                spacecanbepress = false;
            }
        }
        
        //so that would not bouce up slopes
        if (horizontalmovement == 0 && isgrounded() == true)
        {
            body.gravityScale = 0;
        }
        else body.gravityScale = gravity;

        
    }
    private void FixedUpdate()
    {
        if (canmove)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalmovement));
            if (windEffect == false)
            {
                //animator.SetFloat("Speed", Mathf.Abs(horizontalmovement));
                body.velocity = new Vector2(horizontalmovement * movementspeed, body.velocity.y);
            }

            if (windEffect == true) //windeffect
            {
                if (wind == windstate.windRight)
                {
                    WindArrowRight.enabled = true;
                    WindArrowLeft.enabled = false;
                    WindArrowDown.enabled = false;

                    if (horizontalmovement == 0)
                    {
                        body.velocity = new Vector2(-windforcewhenstandingstill, body.velocity.y);
                    }
                    else if (horizontalmovement > 0)
                        body.velocity = new Vector2(horizontalmovement * movementspeed - windforce, body.velocity.y);
                    else body.velocity = new Vector2(horizontalmovement * movementspeed - windforceaddition, body.velocity.y);
                    if (windTimer < windDuration)
                    {
                        windTimer += Time.deltaTime;
                    }
                    else
                    {
                        windRight = true;
                        wind += 1;
                        windTimer = 0;
                    }
                }
                else if (wind == windstate.windLeft)
                {
                    WindArrowRight.enabled = false;
                    WindArrowLeft.enabled = true;
                    WindArrowDown.enabled = false;

                    if (horizontalmovement == 0)
                    {
                        body.velocity = new Vector2(windforcewhenstandingstill, body.velocity.y);
                    }
                    else if
                        (horizontalmovement > 0) body.velocity = new Vector2(horizontalmovement * movementspeed + windforceaddition, body.velocity.y);
                    else body.velocity = new Vector2(horizontalmovement * movementspeed + windforce, body.velocity.y);
                    if (windTimer < windDuration)
                    {
                        windTimer += Time.deltaTime;
                    }
                    else
                    {
                        windRight = false;
                        wind -= 1;
                        windTimer = 0;
                    }
                }
                else
                {
                    WindArrowRight.enabled = false;
                    WindArrowLeft.enabled = false;
                    WindArrowDown.enabled = true;

                    body.velocity = new Vector2(horizontalmovement * movementspeed, body.velocity.y);
                    if (windTimer < windDuration)
                    {
                        windTimer += Time.deltaTime;
                    }
                    else
                    {
                        if (windRight == true)
                            wind += 1;
                        else wind -= 1;
                        windTimer = 0;
                    }
                }

            }
        }
    }

    //function for checking if player is grounded
    public bool isgrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castdistance, layer))
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
    public bool isheadbump()
    {
        if (Physics2D.BoxCast(transform.position, boxsizeforheadbump, 0, transform.up, castdistanceforheadbump, layer))
        {

            return true;
        }
        else 
        {
            
            return false; 
        }
    }
    /*public void OnDrawGizmos() // to visualize groundcheck/isgrounded
    {
        Gizmos.DrawWireCube(transform.position + transform.up * castdistanceforheadbump, boxsizeforheadbump);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform")|| collision.CompareTag("BossTopPlatform"))
        {
            if(canDoubleJump == true)
            {
                secondJump = false;
            }
        }
    }
}
