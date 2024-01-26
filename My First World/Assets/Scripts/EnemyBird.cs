using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Rigidbody2D birdbody;
    //knockback 
    public float knockbacktimer;
    private float timer;
    public bool knockBack;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        birdbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(birdbody.velocity.x > 2)
        {
            birdbody.velocity = new Vector2(2f, birdbody.velocity.y);
        }
        if (birdbody.velocity.y > 2)
        {
            birdbody.velocity = new Vector2(birdbody.velocity.x, 2f);
        }*/
        birdbody.AddForce(-transform.right);
        if (knockBack == false)
        {
            //movement script here
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (transform.position.x > player.transform.position.x)
            {
                birdbody.AddForce(-transform.right);
                //birdbody.AddForce(transform.up);
            }
            else birdbody.AddForce(transform.right);


            if (transform.position.y > player.transform.position.y)
            {
                birdbody.AddForce(-transform.up);
                //birdbody.AddForce(transform.up);
            }
            else birdbody.AddForce(transform.up);



        }
        else
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else //if (timer <= 0)
            {
                timer = knockbacktimer;
                knockBack = false;
            }
        }
    }
}
