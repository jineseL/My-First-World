using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Rigidbody2D SlimeBody;
    public float movespeed;
    
    private bool facingRight = true;
    public Transform Groundcheck;
    public Transform Wallcheck;
    public bool knockBack;

    RaycastHit2D hit;
    RaycastHit2D hit2;
    public LayerMask groundlayers;
    void Start()
    {
        SlimeBody = GetComponent<Rigidbody2D>();
        //Groundcheck = GetComponentInChildren<Transform>();
    }
    private void Update()
    {
            hit = Physics2D.Raycast(Groundcheck.position, -transform.up, 0.3f, groundlayers);
            hit2 = Physics2D.Raycast(Wallcheck.position, transform.right, 0.3f, groundlayers);

        if (knockBack == false)
        {
            if (hit.collider == true && hit2.collider == false)
            {
                if (facingRight == true)
                {
                    SlimeBody.velocity = new Vector2(movespeed, SlimeBody.velocity.y);
                }
                else
                {
                    SlimeBody.velocity = new Vector2(-movespeed, SlimeBody.velocity.y);
                }
            }
            else
            {
                facingRight = !facingRight;
                transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            }
        }
    }


    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (hit.collider != false || hit2.collider != false)
        {
            if (facingRight == true)
            {
                SlimeBody.velocity = new Vector2(movespeed, SlimeBody.velocity.y);
            }
            else
            {
                SlimeBody.velocity = new Vector2(-movespeed, SlimeBody.velocity.y);
            }
        }
        else
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }
    }*/
    
}
