using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;

    //for Invincible affect on enemies
    public float InvDuration;
    private float invTime;
    public bool isInv = false;


    //for knock back affect when enemy is hit
    
    private GameObject player;
    public float knockbackforce;
    private Rigidbody2D body;
    public float enemytype;


    private EnemySlime referencescript;
    private EnemyCup referencescript2;
    private EnemyBird referencescript3;
    private EnemySlimePartol referencescript4;


    // Start is called before the first frame update
    void Start()
    {
        invTime = InvDuration;
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        if (enemytype == 1)
        {
            referencescript = GetComponent<EnemySlime>();
        }
        else if(enemytype == 2)
        {
            referencescript2 = GetComponent<EnemyCup>();
        }
        else if(enemytype == 3)
        {
            referencescript3 = GetComponent<EnemyBird>();
        }
        else if(enemytype == 4)
        {
            referencescript4 = GetComponent<EnemySlimePartol>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInv == true)
        {
            invTimer();
        }
    }
    //when enemy gets hit by player, enemy takes damage, have a invincible timer countdown and a knockback
    public void damage(int damageTaken)
    {
        if (isInv == false)
        {
            health -= damageTaken;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            isInv = true;
            Vector2 direction = (gameObject.transform.position - player.transform.position).normalized;
            Vector2 knockback = direction * knockbackforce;

            //to choose which enemy to stop, lol
            if (enemytype == 1)
            {
                referencescript.knockBack = true; // to stop enemy from moving 
                body.velocity = new Vector2(0, body.velocity.y);
            }


            if (enemytype == 2)
            {
                referencescript2.knockBack = true;
                //body.velocity = new Vector2(0, body.velocity.y);
            }

            if(enemytype == 3)
            {
                referencescript3.knockBack = true;
            }

            if(enemytype == 4)
            {
                referencescript4.knockBack = true;
                body.velocity = new Vector2(0, body.velocity.y);
            }
            body.AddForce(knockback, ForceMode2D.Impulse);
        }
        
    }

    //to make invincible timer
    public void invTimer()
    {
        invTime -= Time.deltaTime;
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
        if (invTime <= 0)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f,255f);
            invTime = InvDuration;
            isInv = false;
            
        }
    }
}
