using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBaoSpawner : MonoBehaviour
{
    public GameObject Bao;
    private float timer;
    public float spawnrate;
    private GameObject[] Baos = new GameObject[2];
    void Start()
    {

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
            for (int i = 0; i < Baos.Length; i++)
            {
                if (Baos[i] == null)
                {
                    Baos[i] = Instantiate(Bao, transform.position, transform.rotation);
                    break;
                }
            }
        }
    }
}
