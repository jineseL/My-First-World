using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updownarrow : MonoBehaviour
{

    public int arrowIndex;
    public float animationSpeed = 2;
    public RectTransform arrow;
    public bool animating;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(arrowIndex > 0)
            {
                animating = true;
                arrowIndex--;
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(arrowIndex < 2)
            {
                animating = true;
                arrowIndex++;
            }
        }

        if (animating)
        {
            Vector3 pos = arrow.localPosition;
            Vector3 screenPos = screen.localPosition;

            if (arrow.localPosition.y < arrowIndex * -260)
            {
                pos.y += animationSpeed * Time.deltaTime;
                arrow.localPosition = pos;
                //arrow.localPosition.y = 5;
                if (arrow.localPosition.y >= arrowIndex * -260)
                {
                    Debug.Log("Done");
                    pos.y = arrowIndex * -260;
                    arrow.localPosition = pos;
                    animating = false;
                }
            }

            if (arrow.localPosition.y > arrowIndex * -260)
            {
                pos.y -= animationSpeed * Time.deltaTime;
                arrow.localPosition = pos;

                if (arrow.localPosition.y <= arrowIndex * -260)
                {
                    pos.y = arrowIndex * -260;

                    arrow.localPosition = pos;
                    animating = false;
                }
            }






        }


    }



}
