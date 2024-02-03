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
    
    void Start()
    {
        spawnpoke();
    }

    // Update is called once per frame
    void Update()
    {
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
