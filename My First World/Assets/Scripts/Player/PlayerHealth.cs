using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //for player to get damage by enemies, for now player is 1 Hp so instance death
    public int health =1;
    private Rigidbody2D PlayerBody;
    public GameObject parent;
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(parent);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemies"))
        {
            health -= 1;
        }
    }
}
