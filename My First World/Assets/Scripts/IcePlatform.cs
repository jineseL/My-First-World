using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    //to addforce to player when player are standing on this platforms
    [SerializeField]
    private GameObject player;
    private bool pushplayerright;
    private bool pushplayerleft;
    private bool topush;
    public float slideforce;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        //adding force to player constantly when player is on the platform
        if (topush == true)
        {
            if (pushplayerright == true && player.GetComponent<PlayerMovement>().isgrounded() == true)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * slideforce);
            }
            if (pushplayerleft == true && player.GetComponent<PlayerMovement>().isgrounded() == true)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * slideforce);
            }
        }
    }
    public void OnCollisionStay2D(Collision2D collision) //check if to see player is facing right or left on platform
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.GetComponent<PlayerMovement>().horizontalmovement > 0 || player.GetComponent<PlayerMovement>().horizontalmovement < 0)//slide only after moving onn the platform
            {
                topush = true;
            }
            if (player.GetComponent<PlayerMovement>().isfacingright == true) //check which direction to slide
            {
                pushplayerleft = false;
                pushplayerright = true;
            }
            else if (player.GetComponent<PlayerMovement>().isfacingright == false)
            {
                pushplayerright = false;
                pushplayerleft = true;
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision) //stop sliding when player jump off platform
    {
        if (collision.gameObject.tag == "Player")
            topush = false;
    }
}
