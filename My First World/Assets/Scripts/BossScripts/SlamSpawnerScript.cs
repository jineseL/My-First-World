using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamSpawnerScript : MonoBehaviour
{
    public GameObject slam;
    /*public float offset = 4.5f;*/
    private GameObject GameCamera;

    //timer
    private float timer;
    public float spawnrate;

    void Start()
    {
        GameCamera = GameObject.FindWithTag("MainCamera");
        spawnslam();
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
            spawnslam();
            timer = 0;
        }
    }
    /*private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, GameCamera.transform.position.y + 7f, transform.position.z);
    }*/
    void spawnslam()
    {
        /*float leftest = transform.position.x - offset;
        float rightest = transform.position.x + offset;*/
        Instantiate(slam, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
