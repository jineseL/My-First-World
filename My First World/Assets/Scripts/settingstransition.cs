using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingstransition : MonoBehaviour
{
    public Animator settingsAnim;
    public int elementsIndex;
    public float animationSpeed = 2;
    public RectTransform elements;
    public bool animatingUp;
    public bool animatingDown;
    public int position;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animatingUp)
        {
            Vector3 pos = elements.localPosition;
            // Vector3 ScreenPos = Screen.localPosition;

            if (elements.localPosition.x < position)
            {
                //pos.x += position;
                // SO ITS NT INSTANT
                pos.x += animationSpeed * Time.deltaTime; 
                elements.localPosition = pos;
                //arrow.localPosition.y = 5;
                if (elements.localPosition.x >= position)
                {
                    pos.x = position;
                    Debug.Log("Done");
                    elements.localPosition = pos;
                    animatingUp = false;
                }
            }
        }


        if (animatingDown)
        {
            Vector3 pos = elements.localPosition;
            // Vector3 ScreenPos = Screen.localPosition;

            if (elements.localPosition.x > position)
            {
                //pos.x += position;
                // SO ITS NT INSTANT
                pos.x -= animationSpeed * Time.deltaTime;
                elements.localPosition = pos;
                //arrow.localPosition.y = 5;
                if (elements.localPosition.x <= position)
                {
                    pos.x = position;
                    Debug.Log("Done");
                    elements.localPosition = pos;
                    animatingDown = false;

                    elements.gameObject.SetActive(false);
                }
            }
            

        }
    }

    public void startanimateup()
    {
        //animatingUp = true;   
        settingsAnim.SetBool("SetingsTransition", false);
    }

    public void startanimatedown()
    {
        //animatingDown = true;
        settingsAnim.SetBool("SetingsTransition", true);
    }

}
