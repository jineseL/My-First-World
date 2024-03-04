using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject bird;
    public float offset = 4.5f;
    private GameObject[] birds = new GameObject[2];
    private float timer;
    public float spawnrate;
    public int currentwave;
    public int totalwave;
    public bool completed;
    void Start()
    {
        completed = false;
        currentwave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            for (int i = 0; i < birds.Length; i++)
            {
                if (birds[i] == null && currentwave < totalwave)
                {
                    currentwave += 1;
                    birds[i] = spawnbird();
                    break;
                }
            }
        }

        if(currentwave >= totalwave)
        {
            completed = true;
        }
    }
    private GameObject spawnbird()
    {
        float lowestpoint = transform.position.y - offset;
        float highestpoint = transform.position.y + offset;
        return Instantiate(bird, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), transform.position.z), transform.rotation);
    }
}
