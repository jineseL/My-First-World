using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnerForSpeedLevel : MonoBehaviour
{
    public GameObject Bird;
    //private bool haspawn;
    public Transform childtransform;
    private float timer;
    public float spawnrate;
    public GameObject player;

    private GameObject[] birds = new GameObject[3]; // this number should be the same as birdcount
    //public int BirdCount=3;
    void Start()
    {
        //Instantiate(Bird, new Vector3(childtransform.position.x, childtransform.position.y, 0), transform.rotation);
        //Debug.Log(birds.Length);
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
                if (birds[i] == null)
                {
                    birds[i] = Instantiate(Bird, new Vector3(childtransform.position.x, childtransform.position.y, 0), transform.rotation);
                    break;
                }

            }
            

        }
        
        transform.position = player.transform.position;
    }
    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        if (haspawn == false)
        {
            if (collider.CompareTag("Player"))
            {
                haspawn = true;
                Instantiate(Bird, new Vector3(childtransform.position.x, childtransform.position.y, 0), transform.rotation);
            }
        }


    }*/
}
