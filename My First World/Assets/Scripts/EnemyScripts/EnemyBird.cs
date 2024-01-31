using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Rigidbody2D birdbody;

    public float maxspeed;
    //knockback 
    public float knockbacktimer;
    private float timer;
    public bool knockBack;
    private PlayerHealth referencescript;

    private bool playerup;
    private bool playerleft;


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
        if (birdbody.velocity.x > maxspeed)
        {
            birdbody.velocity = new Vector2(maxspeed, birdbody.velocity.y);
        }
        if (birdbody.velocity.x < -maxspeed)
        {
            birdbody.velocity = new Vector2(-maxspeed, birdbody.velocity.y);
        }
        if (birdbody.velocity.y > maxspeed)
        {
            birdbody.velocity = new Vector2(birdbody.velocity.x, maxspeed);
        }
        if (birdbody.velocity.y < -maxspeed)
        {
            birdbody.velocity = new Vector2(birdbody.velocity.x, -maxspeed);
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
        if (referencescript.isinv == false)
        {
            if (collider.CompareTag("Player"))
            {
                referencescript.damage(gameObject.transform.position);

            }
        }
    }
}
