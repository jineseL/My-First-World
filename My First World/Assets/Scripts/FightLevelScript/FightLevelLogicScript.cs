using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLevelLogicScript : MonoBehaviour
{
    private float timer;
    public float platformTime;
    public GameObject[] platforms;
    private int previous;
    private int current;
    public EnemySpawnerScript referenceenemyspawnerscript;
    void Start()
    {
        timer = 0;
        previous = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < platformTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            platforms[generaterandomnumber(0, 3)].GetComponent<FightLevelPlatformScript>().alive = true;
        }
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

            if (current == higher - 1)
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
