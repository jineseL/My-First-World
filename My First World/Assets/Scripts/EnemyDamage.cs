using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;

    //for Invincible affect on enemies
    public float InvDuration;
    private float invTime;
    private bool isInv = false;


    //for knock back affect when enemy is hit
    public GameObject player;
    public float knockbackforce;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        invTime = InvDuration;
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
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
            isInv = true;
            Vector2 direction = (gameObject.transform.position - player.transform.position).normalized;
            Vector2 knockback = direction * knockbackforce;
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
