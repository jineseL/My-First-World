using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    //private GameObject HandSlam;
    private SlamMoveScript ReferenceScript;
    private SpriteRenderer sprite;
    private GameObject gamecamera;

    private float timer;
    public float indicatorblinkingduration;
    private bool indicating;
    // Start is called before the first frame update
    void Start()
    {
        //HandSlam = GetComponentInParent<GameObject>();
        ReferenceScript = GetComponentInParent<SlamMoveScript>();
        sprite = GetComponent<SpriteRenderer>();
        gamecamera = GameObject.FindWithTag("MainCamera");


    }

    // Update is called once per frame
    void Update()
    {

        if (ReferenceScript.tracking == true)
        {
            
            if(timer < indicatorblinkingduration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                sprite.enabled = !sprite.enabled;
                timer = 0;
            }
            
        }
        if(ReferenceScript.slamming == true)
        {
            sprite.enabled = true;
            if (transform.parent.transform.position.y <= transform.position.y)
            {
                sprite.enabled = false;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (ReferenceScript.tracking == true)
        {
            transform.position = new Vector3(transform.parent.transform.position.x, gamecamera.transform.position.y + 3.5f, transform.position.z);    
        }
        if(ReferenceScript.slamming == true)
        {
            transform.position = new Vector3(transform.position.x, gamecamera.transform.position.y + 3.5f, transform.position.z);
        }
    }
    

}
