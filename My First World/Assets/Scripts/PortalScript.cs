using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public Dialogue[] dialogue;
    public GameObject dialoguecanvas;
    private PlayerHealth playerhealthscriptreference;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
        playerhealthscriptreference = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            PlayerMovement.windEffect = false;
            PlayerMovement.canDoubleJump = false;
            PlayerMovement.movementspeed = 5;
            LogicManagerScript.RainspawnerEnable = false;
            SceneManager.LoadScene("Tutorial");
            return;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && dialoguecanvas.activeSelf==false)
        {
            //SceneManager.LoadScene(("Dialogue"));
            Time.timeScale = 0;
            player.GetComponent<PlayerMovement>().caninput = false;
            FindObjectOfType<Canvas>().enabled = false;
            //FindObjectOfType<DialogueCanvas>(true).enabled = true;
            dialoguecanvas.SetActive(true);
            //playerhealthscriptreference.invtimer = 0;
            //playerhealthscriptreference.isinv = false;

            FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
            //DialogueManagerScript.instance.StartDialogue(dialogue);
            GetComponent<PortalScript>().enabled = false;
        }
    }
}
