using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeSpawner : MonoBehaviour
{
    public GameObject poke;
    public float offset =4.5f;

    //timer
    private float timer;
    public float spawnrate;

    public float spawndelay;
    public bool todelay;
    private float delaytimer=0;
    private bool firstpsawn;

    public BossScript bossref;

    void Start()
    {
        
        if (todelay == false)
        {
            spawnpoke();
        }
        else 
        { 
            
            timer -= spawndelay; 
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossref.phase2 == true)
        {
            spawnrate = 3.5f;
        }
        if (bossref.phase3 == true)
        {
            spawnrate = 3.5f;
        }
        if (todelay == true)
        {
            if (delaytimer < spawndelay)
            {
                delaytimer += Time.deltaTime;
            }
            else if (firstpsawn == false)
            {
                firstpsawn = true;
                spawnpoke();
            }
        }

        if (timer < spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnpoke();
            timer = 0;
        }
    }
    void spawnpoke()
    {
        float lowestpoint = transform.position.y - offset;
        float highestpoint = transform.position.y + offset;
        Instantiate(poke, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), transform.position.z), transform.rotation);
    }
}
