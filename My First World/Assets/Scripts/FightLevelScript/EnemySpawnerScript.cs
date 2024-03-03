using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject[] enemytospawn;
    private float timer;
    public float spawnrate;
    public int numberOfWave;
    public int wavecounter;
    private int previous;
    private int current;

    public bool completed;
    void Start()
    {
        completed = false;
        wavecounter = 0;
        timer = 0;
        previous = 7;
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
            wavecounter += 1;
            if (wavecounter < numberOfWave)
            {
                spawnRandom();
            }
            /*if(wavecounter >= 4 && wavecounter < numberOfWave)
            {
                spawnRandom();
            }*/
            if(wavecounter >= numberOfWave)
            {
                completed = true;
            }
            timer = 0;
        }
    }
    private void spawnRandom()
    {
        Instantiate(enemytospawn[generaterandomnumber(0,3)], gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    
    private int generaterandomnumber(int lower, int higher)
    {
        current = Random.Range(lower, higher);
        if (previous == 7) //first time
        {
            previous = Random.Range(lower, higher);
            return previous;
        }
        else if (previous == current)
        {
            
            if (current == higher-1)
            {
                current = lower;
                previous = current;
                return current;
            }
            else
            {
                current += 1;
                previous = current;
                return current;
            }
        }
        else
        {
            previous = current;
            return current;
        }
        
    }
}
