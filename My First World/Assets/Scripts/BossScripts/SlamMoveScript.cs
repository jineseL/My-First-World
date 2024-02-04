using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamMoveScript : MonoBehaviour
{
    private GameObject GameCamera;
    private GameObject player;
    private Rigidbody2D body;
    private Animator animator;

    //timer for tracking
    private float tracktimer;
    public float trackduration;
    private bool tracking;

    //for tracking
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothtime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    //for slamming
    private bool slamming;
    public float slamspeed;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        GameCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (tracking == true)
        {
            
            if (tracktimer < trackduration)
            {
                tracktimer += Time.deltaTime;
            }
            else
            {
                tracking = false;
                slamming = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if(tracking == true)
        {
            Vector3 targetposition = player.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
            transform.position = new Vector3(transform.position.x, GameCamera.transform.position.y + 5, 0);
        }
        if(slamming == true)
        {
            body.velocity = -transform.up * slamspeed;
        }
    }
    public void track()
    {
        tracking = true;
        animator.enabled = !animator.enabled;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("BossTopPlatform"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

}
