using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Rigidbody2D SlimeBody;
    public float movespeed;
    
    private bool facingRight = true;
    public Transform Groundcheck;

    RaycastHit2D hit;
    public LayerMask groundlayers;
    void Start()
    {
        SlimeBody = GetComponent<Rigidbody2D>();
        //Groundcheck = GetComponentInChildren<Transform>();
    }
    private void Update()
    {
            hit = Physics2D.Raycast(Groundcheck.position, -transform.up, 1f, groundlayers);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (hit.collider != false)
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
