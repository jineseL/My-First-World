using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatformScript : MonoBehaviour
{
    private float timer;
    public float destroyedduration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            gameObject.GetComponent<Animator>().SetBool("PlatformBoom", true);
            if (timer < destroyedduration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                
                GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<Animator>().SetBool("PlatformBoom", false);
                timer = 0;
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        

        
    }
}
