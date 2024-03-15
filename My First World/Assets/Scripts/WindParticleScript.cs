using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticleScript : MonoBehaviour
{
    private GameObject player;
    private ParticleSystem particlesystem;
    

    void Start()
    {
        player = GameObject.Find("Player");
        particlesystem = GetComponent<ParticleSystem>();
        
    }

    void FixedUpdate()
    {
        
        var fo = particlesystem.forceOverLifetime;
        if (player.GetComponent<PlayerMovement>().wind == PlayerMovement.windstate.windRight || player.GetComponent<PlayerMovement>().wind == PlayerMovement.windstate.windGoingRight)
        {
            fo.x = 1.5f;
        }
        else if(player.GetComponent<PlayerMovement>().wind == PlayerMovement.windstate.windLeft || player.GetComponent<PlayerMovement>().wind == PlayerMovement.windstate.windGoingLeft)
        {
            fo.x = -1.5f;
        }
        //fo.x = new ParticleSystem.MinMaxCurve(-1.5f, -1.5f);
        //transform.position = new Vector3(player.transform.position.x,player.transform.position.y+13.6f,player.transform.position.z);
    }
}
