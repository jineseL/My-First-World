using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSand : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMovementscript;
    private Rigidbody2D body;
    public float fallspeed;
    public float speedReduction;
    public float jumpspeed;
    private bool canjump;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovementscript = player.GetComponent<PlayerMovement>();
        body = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canjump == true)
        {
            if (Input.GetButtonDown("Jump") == true)
            {
                jump();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            //playerMovementscript.gravity = 0.1f;
            
            body.velocity = new Vector2(body.velocity.x-speedReduction, fallspeed);

            canjump = true;

        }
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpspeed);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        canjump = false;
    }
}
