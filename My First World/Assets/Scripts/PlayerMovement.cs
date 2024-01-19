using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    // for horizontal movement
    public float movementspeed;
    private float horizontalmovement;

    //for checking if character is facing right or left
    public bool isfacingright = true;
    private SpriteRenderer playersprite;

    //for jumping & groundcheck
    public float jumpheight;
    //private bool isgrounded; //to check if player is grounded
    public Vector2 boxsize; // for the size of the box to be use in boxcasting
    public float castdistance; //for the cast distance from the centre position of the gameobject 
    public LayerMask layer; // for the layer you want to detect, in this case will be all platform 


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playersprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //for horizontal movement
        horizontalmovement = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalmovement * movementspeed, body.velocity.y);

        //if want to switch to GetAxisRaw
        /*if ((Input.GetKeyUp(KeyCode.A) == true || Input.GetKeyUp(KeyCode.D) == true) && isgrounded() == true) //to make character not bounce when going up slope
        {
            body.velocity = new Vector2(0, 0);
        }*/

        //Direction character is facing check n flipping player sprite
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
        

        //for jumping
        /*isgrounded = isgrounded();*/
        if (Input.GetButtonDown("Jump") == true && isgrounded() == true)
        {
            body.velocity = new Vector2(body.velocity.x, jumpheight);
        }
        //so that would not bouce up slopes
        if (horizontalmovement == 0 && isgrounded() == true)
        {
            body.gravityScale = 0;
        }
        else body.gravityScale = 2;//lol
    }

    //function for checking if player is grounded
    public bool isgrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castdistance, layer))
        {
            return true;
        }
        else return false;
    }
    /*public void OnDrawGizmos() // to visualize groundcheck/isgrounded
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castdistance, boxsize);
    }*/
}
