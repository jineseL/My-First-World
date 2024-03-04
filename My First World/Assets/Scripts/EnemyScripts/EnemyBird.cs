using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    
    private GameObject player;
    private Rigidbody2D birdbody;

    public float maxspeed;
    private float currentspeed = 0;
    //knockback 
    public float knockbacktimer;
    private float timer;
    public bool knockBack;
    private PlayerHealth referencescript;
    public float birdspeed; //must be more than 1

    private bool playerup;
    private bool playerleft;

    /*private float speedtimer;
    public float slowspeedduration;*/

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        birdbody = GetComponent<Rigidbody2D>();
        referencescript = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //for timer
        /*if(speedtimer < slowspeedduration)
        {
            speedtimer += Time.deltaTime;
            maxspeed = 2;
        }
        else
        {
            maxspeed = 5;
        }*/

        

        
        //birdbody.AddForce(transform.right);
        if (knockBack == false)
        {
            //movement script here
            //float distance = Vector3.Distance(player.transform.position, transform.position);
            if (transform.position.x > player.transform.position.x)
            {
                playerleft = true;
                //birdbody.AddForce(transform.up);
            }
            else playerleft = false;


            if (transform.position.y > player.transform.position.y)
            {
                playerup = false;
            }
            else  playerup = true;
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
    private void FixedUpdate()
    {
        if (currentspeed < maxspeed)
        {
            currentspeed += Time.deltaTime* birdspeed;
        }

        if (birdbody.velocity.x > currentspeed)
        {
            birdbody.velocity = new Vector2(currentspeed, birdbody.velocity.y);
        }
        if (birdbody.velocity.x < -currentspeed)
        {
            birdbody.velocity = new Vector2(-currentspeed, birdbody.velocity.y);
        }
        if (birdbody.velocity.y > currentspeed)
        {
            birdbody.velocity = new Vector2(birdbody.velocity.x, currentspeed);
        }
        if (birdbody.velocity.y < -currentspeed)
        {
            birdbody.velocity = new Vector2(birdbody.velocity.x, -currentspeed);
        }
        if(playerleft == true)
        {
            birdbody.AddForce(-transform.right*10);
        }
        else birdbody.AddForce(transform.right*10);
        if (playerup == true)
        {
            birdbody.AddForce(transform.up*10);
        }
        else birdbody.AddForce(-transform.up*10);
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (referencescript.isinv == false && referencescript.isdead == false)
        {
            if (collider.CompareTag("Player"))
            {
                referencescript.damage(gameObject.transform.position);

            }
        }
    }
}
