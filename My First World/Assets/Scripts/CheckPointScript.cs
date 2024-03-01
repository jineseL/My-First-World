using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private PlayerHealth playerhealthscriptreference;
    private LogicManagerScript logicscriptreference;
    public GameObject children;
    private GameObject[] Birds;
    private GameObject[] Birdspawner;
    void Start()
    {
        player = GameObject.Find("Player");
        playerhealthscriptreference = player.GetComponent<PlayerHealth>();
        logicscriptreference = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerhealthscriptreference.health <= 0)
        {
            rebornfromcheckpoint();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerhealthscriptreference.checkpointreach = true;
            //GetComponent<SpriteRenderer>().enabled = false;
            children.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void rebornfromcheckpoint()
    {
        
            Birds = GameObject.FindGameObjectsWithTag("Enemies");
            Birdspawner = GameObject.FindGameObjectsWithTag("BirdSpawner");
            for (int i = 0; i < Birds.Length; i++)
            {
                if (Birds[i].name == "Bird" || Birds[i].name == "Bird(Clone)")
                {
                    Destroy(Birds[i]);
                }
            }
            for (int i = 0; i < Birdspawner.Length; i++)
            {
            Birdspawner[i].GetComponent<BirdTriggerSpawner>().haspawn = false;
            }
            if (playerhealthscriptreference.checkpointreach == true)
            {
                player.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                playerhealthscriptreference.health = 5;
                logicscriptreference.heart1.enabled = true;
                logicscriptreference.heart2.enabled = true;
                logicscriptreference.heart3.enabled = true;
                logicscriptreference.heart4.enabled = true;
                logicscriptreference.heart5.enabled = true;
            }
        
    }
}
