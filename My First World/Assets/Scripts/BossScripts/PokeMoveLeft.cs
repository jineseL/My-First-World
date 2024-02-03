using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeMoveLeft : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    private float rotationz;
    //private float tempz = 178f;
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
    private float destructiontiming = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (aimming == true)
        {
            /*moving.enabled = !moving.enabled;*/
            
            /*Debug.Log("left {0}" + rotationz);*/
            if (timer < shoottiming)
            {
                timer += Time.deltaTime;
            }
            else
            {
                aimming = false;
                //Debug.Log("hi");
                timer = 0;
                moving.enabled = !moving.enabled;
                shoot();
            }

        }
        if (shooting == true)
        {
            if (destroytimer < destructiontiming)
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
            /*Debug.Log("rotationz {0}" + rotationz);
            Debug.Log("tempz is  {0}" + tempz);*/
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationz);

            /*transform.rotation = Quaternion.Euler(0.0f, 0.0f, tempz);
            if (tempz > rotationz )
            {
                if(tempz == 179)
                {
                    tempz = -179;
                }
                else
                tempz -= 1;

            }
            else if (tempz < rotationz)
            {
                if (tempz == -179)
                {
                    tempz = 179;
                }
                else
                tempz += 1;
            }*/
        }

        if (shooting == true)
        {
            body.velocity = transform.right * speed;
           
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
