using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    //to addforce to player when player are standing on this platforms
    /*[SerializeField]*/
    private GameObject player;
    private bool pushplayerright;
    private bool pushplayerleft;
    public bool topush;

    //to allow for left and right turns speed
     public float slideForceRight;
     public float slideForceLeft;

    //max amount of slideforce
    public float slideForce;

    //slidedelay to continue sliding for a shortwhile after jumping off so to continue momentum
    private bool isgroundedonice;
    private float slideovertimeCounter;
    public float slideovertime;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        slideForceRight = 0;
        slideForceLeft = 0;
    }
    private void Update()
    {
        
        if (isgroundedonice == false)
        {
            slideovertimeCounter -= Time.deltaTime;
        }
        if(isgroundedonice == true)
        {
            slideovertimeCounter = slideovertime;
        }
        if(slideovertimeCounter > 0f)
        {
            topush = true;
        }
        if (slideovertimeCounter <= 0f)
        {
            topush = false;
        }


        //to clamp the speed of the sliding
        if (slideForceRight >= slideForce)
            slideForceRight = slideForce;

        if (slideForceRight <= 0f)
            slideForceRight = 0f;

        if (slideForceLeft >= slideForce)
            slideForceLeft = slideForce;

        if (slideForceLeft <= 0f)
            slideForceLeft = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isgroundedonice == false)
        {
            slideForceLeft -= 1;
            slideForceRight -= 1;
            
        }
        //adding force to player constantly when player is on the platform
        if (topush == true)
        {

            if (pushplayerright == true /*&& player.GetComponent<PlayerMovement>().isgrounded() == true*/)
            {
                if (isgroundedonice == true && player.GetComponent<PlayerMovement>().horizontalmovement > 0)
                {
                    slideForceRight += 2;
                    slideForceLeft -= 2;
                }
                if (isgroundedonice == true && player.GetComponent<PlayerMovement>().horizontalmovement == 0)
                {
                    slideForceRight -= 1f;
                    slideForceLeft -= 1f;
                }

                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * slideForceRight);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * slideForceLeft);
            }
            if (pushplayerleft == true /*&& player.GetComponent<PlayerMovement>().isgrounded() == true*/)
            {
                if (isgroundedonice == true && player.GetComponent<PlayerMovement>().horizontalmovement < 0)
                {
                    slideForceRight -= 2;
                    slideForceLeft += 2;
                }
                if (isgroundedonice == true && player.GetComponent<PlayerMovement>().horizontalmovement == 0)
                {
                    slideForceRight -= 1f;
                    slideForceLeft -= 1f;
                }
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * slideForceRight);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * slideForceLeft);
            }
        }

        
        

    }
    public void OnCollisionStay2D(Collision2D collision) //check if to see player is facing right or left on platform
    {
        if (collision.gameObject.tag == "Player")
        {
            isgroundedonice = true;
            if (player.GetComponent<PlayerMovement>().horizontalmovement > 0 || player.GetComponent<PlayerMovement>().horizontalmovement < 0)//slide only after moving onn the platform
            {
                
                topush = true;
            }
            if (player.GetComponent<PlayerMovement>().isfacingright == true) //check which direction to slide
            {
                pushplayerleft = false;
                pushplayerright = true;
            }
            else if (player.GetComponent<PlayerMovement>().isfacingright == false)
            {
                pushplayerright = false;
                pushplayerleft = true;
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision) //stop sliding when player jump off platform
    {
        if (collision.gameObject.tag == "Player")
        {

            
            isgroundedonice = false;

            //topush = false;
        }
    }
}
