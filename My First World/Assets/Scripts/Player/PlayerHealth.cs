using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //for player to get damage by enemies, for now player is 1 Hp so instance death
    public int health;
    private Rigidbody2D PlayerBody;
    
    public float knockbackforce;

    //inv timer
    private float invtimer;
    public float invduration;
    public bool isinv;

    //for knockback
    private float timer;
    public float knockbackduration;

    //timescale
    private float fixedDeltaTime;
    private float unscaledtimer;
    public static bool timefreeze;
    public float unscaledtimerduration;

    //logic manager
    private LogicManagerScript logicscriptreference;

    

    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        this.fixedDeltaTime = Time.fixedDeltaTime;
        logicscriptreference = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timefreeze == true)
        {
            freezescreen();
        }
        if (isinv == true )
        {
            invTimer();
            
        }
        if(PlayerMovement.canmove == false)
        {
            if(timer < knockbackduration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                PlayerMovement.canmove = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (isinv == false)
        {
            if (collider.gameObject.CompareTag("Enemies"))
            {
                damage(collider.transform.position);
            }
        }
    }
    
    public void damage(Vector3 position)
    {
        logicscriptreference.minushealth();
        health -= 1;
        if(health == 0)
        {
            death();
        }
        timefreeze = true;
        isinv = true;
        Vector2 direction = (gameObject.transform.position - position).normalized;
        direction.y = 0;
        if (direction.x > 0)
        {
            direction.x = 1;
        }
        else
        {
            direction.x = -1;
        }
        Vector2 knockback = direction * knockbackforce;

        
        PlayerMovement.canmove = false;
        PlayerBody.AddForce(knockback,ForceMode2D.Impulse);
        //PlayerMovement.canmove = true;

    }
    public void damagewithoutknockback()
    {
        logicscriptreference.minushealth();
        health -= 1;
        if (health == 0)
        {
            death();
        }
        isinv = true;
    }
    public void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void invTimer()
    {
        
        invtimer += Time.deltaTime;
        Physics2D.IgnoreLayerCollision(6, 10, true);
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
        
        
        if (invtimer >= invduration)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
            invtimer = 0;
            Physics2D.IgnoreLayerCollision(6, 10, false);
            isinv = false;
        }
    }
    private void freezescreen()
    {
        unscaledtimer += Time.unscaledDeltaTime;
        Time.timeScale = 0;
        if (unscaledtimer >= unscaledtimerduration)
        {
            Time.timeScale = 1;
            timefreeze = false;
            unscaledtimer = 0;
        }
    }
}
