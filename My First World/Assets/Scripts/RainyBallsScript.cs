using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainyBallsScript : MonoBehaviour
{
    public float rainaccleration;
    private Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        /*rainaccleration++;

        transform.position = new Vector3(transform.position.x ,transform.position.y,transform.position.z);*/
        body.gravityScale += rainaccleration;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerHealth>().damage(transform.position);
            Destroy(gameObject);
        }
        if (collider.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
