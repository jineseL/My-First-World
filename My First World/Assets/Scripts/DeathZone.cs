using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private float timer;
    private float countdown = 0.2f;
    private bool checker;

    public Transform respawnpoint;
    private void Update()
    {
        if (checker == true)
        {
            if (timer < countdown)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                checker = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (checker == false)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHealth>().damagewithoutknockback();
                checker = true;
                collider.GetComponent<Transform>().position = new Vector3(respawnpoint.position.x, respawnpoint.position.y, respawnpoint.position.z);
            }
            
        }
    }
}
