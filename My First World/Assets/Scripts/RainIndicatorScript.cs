using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainIndicatorScript : MonoBehaviour
{
    private GameObject cameraX;
    public GameObject indicator;

    Renderer rd;
    // Start is called before the first frame update
    void Start()
    {
        cameraX = GameObject.Find("CameraFollow");
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > cameraX.transform.position.y + 4)
        {
            if (indicator.activeSelf == false)
            {
                indicator.SetActive(true);
            }

            indicator.transform.position = new Vector3(gameObject.transform.position.x, cameraX.transform.position.y + 4, gameObject.transform.position.z);
        }
        else
        {
            if (indicator.activeSelf == true)
            {
                indicator.SetActive(false);
            }
        }
    }
}
