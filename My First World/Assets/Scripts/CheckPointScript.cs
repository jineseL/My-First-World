using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private PlayerHealth playerhealthscriptreference;
    private LogicManagerScript logicscriptreference;
    void Start()
    {
        player = GameObject.Find("Player");
        playerhealthscriptreference = player.GetComponent<PlayerHealth>();
        logicscriptreference = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerhealthscriptreference.health == 0)
        {
            if (playerhealthscriptreference.checkpointreach == true)
            {
                player.transform.position = transform.position;
                playerhealthscriptreference.health = 5;
                logicscriptreference.heart1.enabled = true;
                logicscriptreference.heart2.enabled = true;
                logicscriptreference.heart3.enabled = true;
                logicscriptreference.heart4.enabled = true;
                logicscriptreference.heart5.enabled = true;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerhealthscriptreference.checkpointreach = true;
    }
}
