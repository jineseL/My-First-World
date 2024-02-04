using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeMoveScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    private float angle;
    private Rigidbody2D body;

    private float timer;
    public float shoottiming;

    //for speed of hand
    public float speed;

    //for enabling and disable
    public bool aimming;
    private bool shooting;
    public Animator moving;

    //for destroying object
    private float destroytimer;
    private float destructiontiming =3.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (aimming == true)
        {
            //moving.enabled = !moving.enabled;
            direction = player.transform.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            if (timer < shoottiming)
            {
                timer += Time.deltaTime;
            }
            else
            {
                aimming = false;
                timer = 0;
                moving.enabled = !moving.enabled;
                shoot();
            }

        }
        if(shooting == true)
        {
            if(destroytimer < destructiontiming)
            {
                destroytimer += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
            
        
    }
    private void FixedUpdate()
    {
        if (aimming == true)
        {
            if (body.rotation < angle)
            {
                //tracking speed of the finger change both to fix
                body.rotation += 1;
            }
            else if(body.rotation > angle)
                body.rotation -= 1;
        }

        if(shooting == true)
        {
            body.velocity = transform.right*speed;
            
            
        }
        //body.transform.position = transform.forward;
    }
    public void aim()
    {
        aimming = true;
    }
    private void shoot()
    {
        shooting = true;
    }
}
