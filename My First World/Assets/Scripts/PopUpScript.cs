using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject PopupImage;
    
    
    private GameObject gamecamera;
    private Color imagecolor;
    public float fadespeed;
    private bool fadeintime;
    private bool fadeouttime;
    //private bool at255;
    float fadeamount; // opacity is at 1 not 255 fml

    // Start is called before the first frame update
    void Start()
    {
        fadeintime = false;
        fadeamount = 0;
        gamecamera = GameObject.Find("Main Camera");
        imagecolor = PopupImage.GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update() //if fade in time = true, image will fade in 
    {
        
        //PopupImage.transform.position = new Vector3(gamecamera.transform.position.x, gamecamera.transform.position.y, transform.position.z);
        if (fadeintime == true)
        {

            PopupImage.transform.position = new Vector3(gamecamera.transform.position.x, gamecamera.transform.position.y, transform.position.z);
            Color objectcolor = PopupImage.GetComponent<SpriteRenderer>().color;
             //fadeamount = objectcolor.a + (fadespeed * Time.deltaTime);

            if (imagecolor.a < 1)
            {
                fadeamount = objectcolor.a + (fadespeed * Time.deltaTime);
                //fadeamount = 255;
                //fadeintime = false;
            }
            imagecolor = new Color(imagecolor.r, imagecolor.g, imagecolor.b, fadeamount);
            PopupImage.GetComponent<SpriteRenderer>().color = imagecolor;
        }

        if (fadeouttime == true)
        {
            PopupImage.transform.position = new Vector3(gamecamera.transform.position.x, gamecamera.transform.position.y, transform.position.z);
            Color objectcolor = PopupImage.GetComponent<SpriteRenderer>().color;
             //fadeamount = objectcolor.a - (fadespeed * Time.deltaTime);

            if (imagecolor.a > 0)
            {
                fadeamount = objectcolor.a - (fadespeed * Time.deltaTime);
                //fadeamount = 0;
                //PopupImage.SetActive(false);
            }
            if(imagecolor.a <= 0)
            {
                PopupImage.SetActive(false);
            }
            imagecolor = new Color(imagecolor.r, imagecolor.g, imagecolor.b, fadeamount);
            PopupImage.GetComponent<SpriteRenderer>().color = imagecolor;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Player"))
        {
            
            PopupImage.SetActive(true);

            
                fadeintime = true;
            
            fadeouttime = false;
            
            //collider.gameObject.GetComponent<PlayerMovement>().caninput = false;
        }   
    }
    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            //Debug.Log("exited");
            fadeintime = false;
            fadeouttime = true;
        }
    }
    
}
