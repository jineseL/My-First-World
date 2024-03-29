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
    

    //for checking if slime is at the edge or hitting a wall, know when to turn back
    RaycastHit2D hit; //groundcheck
    RaycastHit2D hit2; //wallcheck
   // RaycastHit2D hit3; //enemycheck
    public LayerMask groundlayers;
    public LayerMask enemylayerl;

    //for checking if slime is knockback
    
    public float knockbacktimer;
    private float timer;
    public bool knockBack;
    private Animator m_Animator;
    void Start()
    {
        SlimeBody = GetComponent<Rigidbody2D>();
        timer = knockbacktimer;
        m_Animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(10, 10, true);
        //Groundcheck = GetComponentInChildren<Transform>();
    }
    private void Update()
    {
            hit = Physics2D.Raycast(Groundcheck.position, -transform.up, 0.5f, groundlayers);
            hit2 = Physics2D.Raycast(Wallcheck.position, transform.right, 0.3f, groundlayers);
        //hit3 = Physics2D.Raycast(Wallcheck.position, transform.right, 0.05f, enemylayerl);
        //Physics2D.IgnoreLayerCollision(10, 10,true);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (knockBack == false)
        {

            if (hit.collider == true && hit2.collider == false /*&& hit3.collider == false*/)
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
        else
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                m_Animator.SetBool("GotHit", true);
            }
            else //if (timer <= 0)
            {
                timer = knockbacktimer;
                knockBack = false;
                m_Animator.SetBool("GotHit", false);
            }
        }
    }

}
