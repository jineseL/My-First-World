using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTriggerSpawner : MonoBehaviour
{
    public GameObject Bird;
    public bool haspawn;
    public Transform childtransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (haspawn == false)
        {
            if (collider.CompareTag("Player"))
            {
                haspawn = true;
                Instantiate(Bird, new Vector3(childtransform.position.x, childtransform.position.y, 0), transform.rotation);
            }
        }

        
    }
}
