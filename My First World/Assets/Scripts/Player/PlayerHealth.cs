using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    public int health =5;
    private Rigidbody2D PlayerBody;
    
    public float knockbackforce;

    //inv timer
    private float invtimer;
    public float invduration;
    public bool isinv = false;

    //for knockback
    private float timer = 0;
    public float knockbackduration;

    //timescale
    private float fixedDeltaTime = 0;
    private float unscaledtimer = 0;
    public static bool timefreeze;
    public float unscaledtimerduration;

    //logic manager
    private LogicManagerScript logicscriptreference;

    //camera shake
    private GameObject gamecamera;
    private Animator gamecameraanimator;
    private Animator Manim;

    //checkpoint
    public bool checkpointreach;

    public bool isdead;

    private bool dying;
    void Start()
    {
        Manim = GetComponent<Animator>();
        isdead = false;
        dying = false;
        checkpointreach = false;
        isinv = false;
        Physics2D.IgnoreLayerCollision(6, 10, false);
        gamecamera = GameObject.Find("Main Camera");
        gamecameraanimator = gamecamera.GetComponent<Animator>();
        PlayerBody = GetComponent<Rigidbody2D>();
        this.fixedDeltaTime = Time.fixedDeltaTime;
        logicscriptreference = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isdead == true)
        {
            Physics2D.IgnoreLayerCollision(6, 10, true);
        }
        else Physics2D.IgnoreLayerCollision(6, 10, false);

        if(dying == true)
        {
            PlayerBody.velocity = new Vector2(0, 0);
        }
        if (timefreeze == true)
        {
            freezescreen();
        }
        if (isinv == true )
        {
            invTimer();
            Manim.SetBool("invi", true);
        }
        else
        {
            Manim.SetBool("invi", false);
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
            //Debug.Log("hi");
            if (collider.gameObject.CompareTag("Enemies"))
            {
                /*Debug.Log("hi");*/
                damage(collider.transform.position);
            }
        }
    }
    
    public void damage(Vector3 position)
    {
        health -= 1;
        logicscriptreference.minushealth();
        if (health <= 0)
        {
            isdead = true;
            deathanim();
            return;
        }
        gamecameraanimator.SetTrigger("Damage");
        
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
        //logicscriptreference.minushealth();
        if (isinv == false)
        {
            logicscriptreference.minushealth();
            health -= 1;
        }
        if (health <= 0)
        {
            isdead = true;
            deathanim();
            return;
        }
        isinv = true;
    }
    public void deathanim()
    {
        //PlayerBody.isKinematic = true;
        //Physics2D.IgnoreLayerCollision(6, 10, true);
        //PlayerBody.velocity = new Vector2(0, 0);
        dying = true;
        gameObject.GetComponent<PlayerMovement>().caninput = false;
        Manim.SetTrigger("Death");
    }
    public void death()
    {
        dying = false;
        if (checkpointreach == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            return;
        }
        else
        {

            isdead = false;
            Manim.SetTrigger("Respawn");
            //PlayerBody.isKinematic = false;
            gameObject.GetComponent<PlayerMovement>().caninput = true;
            GameObject.Find("CheckPoint").GetComponent<CheckPointScript>().rebornfromcheckpoint();
            return;
        }
        
    }
    private void invTimer()
    {
        
        invtimer += Time.deltaTime;
        Physics2D.IgnoreLayerCollision(6, 10, true);
        //gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
        
        
        if (invtimer >= invduration)
        {
            //gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
            invtimer = 0;
            Physics2D.IgnoreLayerCollision(6, 10, false);
            isinv = false;
            
           // Manim.SetBool("invi", false);
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
