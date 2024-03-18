using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialfreezepopupscript : MonoBehaviour
{
    //public GameObject toshow;
    float timer;
    public float tutorialduration; //before press enter to continue pops up 
    bool activated = false;
    GameObject player;


    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            if(timer < tutorialduration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Time.timeScale = 1;
                player.GetComponent<PlayerMovement>().caninput = true;
                FindObjectOfType<Canvas>().enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Time.timeScale = 0;
            collider.GetComponent<PlayerMovement>().caninput = false;
            FindObjectOfType<Canvas>().enabled = false;
            activated = true;
        }
    }
}
