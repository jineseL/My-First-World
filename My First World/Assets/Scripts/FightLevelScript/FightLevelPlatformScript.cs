using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLevelPlatformScript : MonoBehaviour
{
    //for ice interaciton
    private bool grounded;
    public IcePlatform IcePlatformscript;

    //timer to rebuild
    public bool alive;
    private float timer;
    public float aliveduration;
    void Start()
    {
        alive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (/*gameObject.GetComponent<Animator>().GetBool("Rebuild")*/alive == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Rebuild", true);
            timer += Time.deltaTime;
            
        }
        //when destroyed
        if(timer >= aliveduration)
        {
            timer = 0;
            alive = false;
            gameObject.GetComponent<Animator>().SetBool("Rebuild", false);
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
    private void FixedUpdate()
    {
        if (grounded == true)
        {
            IcePlatformscript.slideForceRight = 0;
            IcePlatformscript.slideForceLeft = 0;
        }
    }
    private void rebuildcollider()
    {
        
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void SettingTrigger()
    {
        
        gameObject.GetComponent<Animator>().SetTrigger("DestroyedComplete");
    }


    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            grounded = false;
        }
    }
}
