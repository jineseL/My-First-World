using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public Dialogue[] dialogue;
    public GameObject dialoguecanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            //SceneManager.LoadScene(("Dialogue"));
            Time.timeScale = 0;
            FindObjectOfType<Canvas>().enabled = false;
            //FindObjectOfType<DialogueCanvas>(true).enabled = true;
            dialoguecanvas.SetActive(true);

            FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
        }
    }
}
