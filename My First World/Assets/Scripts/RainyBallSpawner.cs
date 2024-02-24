using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainyBallSpawner : MonoBehaviour
{
    public GameObject rainyball;
    private GameObject GameCamera;
    public float offset;
    private GameObject player;

    public float abovecameradistance;
    //timer
    private float timer;
    public float spawnrate;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GameCamera = GameObject.FindWithTag("MainCamera");
        
        /*firstspawn();*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, GameCamera.transform.position.y+ abovecameradistance,0);
        if (timer < spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnrain();
            timer = 0;
        }
    }
    void spawnrain()
    {
        float rightest;
        float leftest;
        if (PlayerMovement.movementspeed == 8)
        {
            leftest = transform.position.x - offset+3;
            rightest = transform.position.x + offset-1;
        }
        else 
        {
            rightest = transform.position.x + offset;
            leftest = transform.position.x - offset;
        }

         
        
        Instantiate(rainyball, new Vector3(Random.Range(leftest, rightest), transform.position.y, transform.position.z), transform.rotation);
    }
    /*void firstspawn()
    {
        Instantiate(rainyball, new Vector3(transform.position.x+3f, transform.position.y, transform.position.z), transform.rotation);
    }*/
}

