using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    // for horizontal movement
    public static float movementspeed = 5;
    public float horizontalmovement;
    public static bool canmove;

    //for checking if character is facing right or left
    public bool isfacingright = true;
    private SpriteRenderer playersprite;

    //for jumping & groundcheck
    public float jumpheight;
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
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playersprite = GetComponent<SpriteRenderer>();
        isfacingright = true;
        canmove = true;
        //windEffect = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //for horizontal movement
        
            horizontalmovement = Input.GetAxis("Horizontal");




        //if want to switch to GetAxisRaw
        /*if ((Input.GetKeyUp(KeyCode.A) == true || Input.GetKeyUp(KeyCode.D) == true) && isgrounded() == true) //to make character not bounce when going up slope
        {
            body.velocity = new Vector2(0, 0);
        }*/

        //Direction character is facing check n flipping player sprite
        if (PlayerHealth.timefreeze == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                isfacingright = false;
                playersprite.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                isfacingright = true;
                playersprite.flipX = false;
            }
        }


        //for jumping
        /*isgrounded = isgrounded();*/
        if (canmove)
        {
            if (canDoubleJump == false)
            {
                if (Input.GetButtonDown("Jump") == true && isgrounded() == true /*&& canjump ==true*/)
                {
                    /*canjump = false;*/
                    body.velocity = new Vector2(body.velocity.x, jumpheight);
                    //body.AddForce(transform.up * jumpheight);
                }
            }
            else//for double jumping
            {
                if (secondJump == false)
                {
                    if (Input.GetButtonDown("Jump") == true && isgrounded() == true /*&& canjump ==true*/)
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpheight);
                        secondJump = true;
                    }
                }
                else
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpheight);
                        secondJump = false;
                    }
                }
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
            if (windEffect == false)
            {
                body.velocity = new Vector2(horizontalmovement * movementspeed, body.velocity.y);
            }

            if (windEffect == true) //windeffect
            {
                if (wind == windstate.windRight)
                {
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
    /*public void OnDrawGizmos() // to visualize groundcheck/isgrounded
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castdistance, boxsize);
    }*/
}
