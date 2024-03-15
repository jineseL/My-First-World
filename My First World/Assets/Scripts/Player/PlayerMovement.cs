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
    public bool caninput;

    //for checking if character is facing right or left
    public bool isfacingright = true;
    private Attack attackreferencescript;
    //public static bool canturn=true; if u wan to allow turning while attack 
    //private SpriteRenderer playersprite;

    //for jumping & groundcheck
    public float jumpheight;
    
    //private float jumping;
    private bool spacecanbepress;
    private float jumptimer;
    private float jumpduration=0.3f;
    private bool falloffledgejump; //jumping after falling off a ledge
    //private bool headbump; //player head hit ceiling
    public float castdistanceforheadbump;
    public Vector2 boxsizeforheadbump;

    //Coyote Time
    private float cyotetetime = 0.1f;
    private float cyotetetimeCounter;

    //jump buffering
    private float jumpbuffertimer = 0.1f;
    private float jumpbuffercounter;

    //private bool canjump; //to prevent continous jumping
    public Vector2 boxsize; // for the size of the box to be use in boxcasting
    public float castdistance; //for the cast distance from the centre position of the gameobject 
    public LayerMask layer; // for the layer you want to detect, in this case will be all platform 
    public float gravity;

    //for double jumping
    public static bool canDoubleJump;
    public bool secondJump = false;

    //for wind effect
    public static bool windEffect; //to activate on the dialouge
    
    public enum windstate
    {
        windRight,
        windGoingLeft,
        windLeft,
        windGoingRight,
        
    }
    private float windTimer = 0;
    public float windforce;
    //public float windforceaddition;
    public float windDuration; // wind duration to blow at 1 direction
    public windstate wind = windstate.windGoingRight;
    /*public int numbersofframestochangewindstate;
    private float windframes;*/
    private float windinterpolation;
    public float windacceleration; // speed of how fast wind switches

    //for alpha wind indicator should switch to partical effect after alpha
    /*public Image WindArrowLeft;
    public Image WindArrowDown;
    public Image WindArrowRight;*/


    private Animator animator;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //playersprite = GetComponent<SpriteRenderer>();
        isfacingright = true;
        canmove = true;
        animator = GetComponent<Animator>();
        canmove = true;
        caninput = true;
        attackreferencescript = GetComponent<Attack>();
        windinterpolation = 0.5f;
        //windEffect = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        //for horizontal movement
        animator.SetFloat("IsFalling", body.velocity.y);
        if (caninput)
        {
            horizontalmovement = Input.GetAxis("Horizontal");
        }
        animator.SetBool("GotHit", !canmove);
        if (body.velocity.y < -1)
        {
            animator.SetBool("IsJumping", false);
        }
        if (isgrounded() == true)
        {
            animator.SetBool("Isgrounded", true);
        }
        else animator.SetBool("Isgrounded", false);

        //for cyotetetime
        if (isgrounded() == true)
        {
            cyotetetimeCounter = cyotetetime;
        }
        else
        {
            cyotetetimeCounter -= Time.deltaTime;
        }

        //for jump buffering
        if (Input.GetButtonDown("Jump"))
        {
            jumpbuffercounter = jumpbuffertimer;
        }
        else jumpbuffercounter -= Time.deltaTime;



        //Direction character is facing check n flipping player sprite
        if (PlayerHealth.timefreeze == false)
        {
            if (caninput)
            {

                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.D) != true)
                    {
                        if (isfacingright == true)
                        {
                            if (attackreferencescript.attacking == false)
                            {
                                isfacingright = false;
                                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            }
                        }
                    }
                    //isfacingright = false;
                    //playersprite.flipX = true;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    if (isfacingright == false)
                    {
                        //isfacingright = true;
                        if (attackreferencescript.attacking == false)
                        {
                            isfacingright = true;
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                        }
                    }
                    //isfacingright = true;
                    //playersprite.flipX = false;
                }
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
        if (canmove && caninput)
        {
            if (canDoubleJump == false)
            {
                if (jumpbuffercounter > 0f && cyotetetimeCounter >0f /*&& canjump ==true*/)
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
                    if (jumpbuffercounter >0f && cyotetetimeCounter > 0f && isheadbump()==false)
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
            jumpbuffercounter = 0f;
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
                    cyotetetimeCounter = 0f;
                    body.velocity = new Vector2(body.velocity.x, 2.5f);
                    spacecanbepress = false;

                }
            }
            else
            {
                animator.SetBool("IsJumping", false);
                jumptimer = 0;
                //body.velocity = new Vector2(body.velocity.x, -0);
                body.velocity = new Vector2(body.velocity.x, 0.5f);
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
        if (canmove && caninput)
        {
            //wind effect
            animator.SetFloat("Speed", Mathf.Abs(horizontalmovement));
            if (windEffect == false)
            {
                //animator.SetFloat("Speed", Mathf.Abs(horizontalmovement));
                body.velocity = new Vector2(horizontalmovement * movementspeed, body.velocity.y);
                
                //body.AddForce(-transform.right*testing);
            }

            if (windEffect == true)
            {
                body.velocity = new Vector2(horizontalmovement * movementspeed, body.velocity.y);

                body.AddForce((Vector3.Lerp(-Vector3.right, Vector3.right, windinterpolation))*windforce);

                if (wind == windstate.windRight) //WIND RIGHT
                {
                    if (windTimer < windDuration)
                    {
                        windTimer += Time.deltaTime;
                        
                    }
                    else
                    {
                        //windRight = true;
                        wind += 1; //switching state to windgoingleft
                        windTimer = 0;
                        
                    }
                }
                else if(wind == windstate.windGoingLeft) // WIND GOING LEFT
                {
                    if(windinterpolation < 1)
                    {
                        windinterpolation += Time.deltaTime*windacceleration;
                        
                    }
                    else
                    {
                        wind += 1; //switching state to windleft
                    }

                }
                else if (wind == windstate.windLeft) //WIND LEFT
                {
                    if (windTimer < windDuration)
                    {
                        windTimer += Time.deltaTime;
                        
                    }
                    else
                    {
                        //windRight = true;
                        wind += 1;//switching state to windgoingright
                        windTimer = 0;
                    }
                }
                else if (wind == windstate.windGoingRight) // WIND GOING RIGHT
                {
                    if (windinterpolation > 0)
                    {
                        windinterpolation -= Time.deltaTime * windacceleration;
                        
                    }
                    else
                    {
                        wind = windstate.windRight; //returning wind state to wind right
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
