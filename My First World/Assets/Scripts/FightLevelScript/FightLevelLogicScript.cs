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
    public GameObject baospawner1;
    public GameObject baospawner2;
    public GameObject MiniBoss;
    public GameObject healthbar;
    public GameObject tinyboss;
    public GameObject portal;

    private float breaktimer;
    public float breakduration;

    private GameObject[] Enemies;

    private bool bossfight;
    void Start()
    {
        bossfight = true;
        timer = 0;
        breaktimer = 0;
        previous = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceenemyspawnerscript.completed == false)
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
        else if(enemycheck() == true)
        {
            if (breaktimer < breakduration)
            {
                breaktimer += Time.deltaTime;
            }
            else
            {
                if (bossfight == true)
                {
                    baospawner1.SetActive(true);
                    baospawner2.SetActive(true);
                    healthbar.SetActive(true);
                    MiniBoss.SetActive(true);
                    bossfight = false;
                }
            }
        }
        if(MiniBoss == null)
        {
            baospawner1.SetActive(false);
            baospawner2.SetActive(false);
            destroyallenemies();
            tinyboss.SetActive(true);
            portal.SetActive(true);
            healthbar.SetActive(false);
        }
    }

    private bool enemycheck()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if(Enemies[i] != null)
            {
                return false;
            }
        }
        return true;
    }
    private void destroyallenemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i] != null)
            {
                Destroy(Enemies[i]);
            }
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
