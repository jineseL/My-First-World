using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject PopupImage;
    static bool activated;
    private GameObject gamecamera;
    // Start is called before the first frame update
    void Start()
    {
        gamecamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PopupImage.SetActive(true);
            
            PopupImage.transform.position = new Vector3(gamecamera.transform.position.x,gamecamera.transform.position.y,transform.position.z);
            //collider.gameObject.GetComponent<PlayerMovement>().caninput = false;
        }   
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PopupImage.SetActive(false);
        }
    }
}
