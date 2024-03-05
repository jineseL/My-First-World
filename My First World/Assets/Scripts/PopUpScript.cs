using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject PopupImage;
    static bool activated;
    private GameObject gamecamera;
    private Color imagecolor;
    public float fadespeed;
    private bool fadeintime;
    private bool fadeouttime;
    
    // Start is called before the first frame update
    void Start()
    {
        fadeintime = false;
        
        gamecamera = GameObject.Find("Main Camera");
        imagecolor = PopupImage.GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update()
    {
        PopupImage.transform.position = new Vector3(gamecamera.transform.position.x, gamecamera.transform.position.y, transform.position.z);
        if (fadeintime == true)
        {
            Color objectcolor = PopupImage.GetComponent<SpriteRenderer>().color;
            float fadeamount = objectcolor.a + (fadespeed * Time.deltaTime);

            if (imagecolor.a >= 255)
            {
                fadeamount = 255;
            }
            imagecolor = new Color(imagecolor.r, imagecolor.g, imagecolor.b, fadeamount);
            PopupImage.GetComponent<SpriteRenderer>().color = imagecolor;
        }
        if (fadeouttime == true)
        {
            Color objectcolor = PopupImage.GetComponent<SpriteRenderer>().color;
            float fadeamount = objectcolor.a - (fadespeed * Time.deltaTime);

            if (imagecolor.a <= 0)
            {
                fadeamount = 0;
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
            
            fadeintime = false;
            fadeouttime = true;
        }
    }
    
}
