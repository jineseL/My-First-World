using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{
    private GameObject[] btn;
    int numberofbuttons;
    public GameObject redbutton;
    public float redbuttonrange;

    private int selectedbtn=0;

    private float horizontal;
    private float vertical;

    private bool buttonpressed;
    GameObject firstbutton;
    void Update()
    {
        // make an array of all gameobject tag with button
        btn = GameObject.FindGameObjectsWithTag("Button");

        if (btn.Length > 0)
        {
            //check if panel has change
            if (firstbutton != btn[0] || numberofbuttons != btn.Length)
            {
                selectedbtn = 0;
            }
            
            firstbutton = btn[0];
            numberofbuttons = btn.Length;


            //Highlight the selected button
            for (int i =0; i < btn.Length; i++)
            {
                if (i == selectedbtn)
                {
                    btn[i].GetComponent<Button>().Select();
                    if(btn[i].name != "Continue Button")
                    {
                        redbutton.SetActive(true);
                        redbutton.transform.position = new Vector3(btn[i].transform.position.x- redbuttonrange, btn[i].transform.position.y, btn[i].transform.position.z);
                        //btn[i].transform.Find("RedArrow").gameObject.SetActive(true); //transform might be a problem here
                    }
                    /*else
                    {
                        if (btn[i].name != "Continue Button")
                        {
                            btn[i].transform.Find("RedArrow").gameObject.SetActive(false);
                        }
                    }*/
                }
            }

            //get position of selected button
            Vector3 btn_position = btn[selectedbtn].GetComponent<RectTransform>().position;

            //array for difference in the position of the buttons
            float[] hort_dif = new float[btn.Length];
            float[] vert_dif = new float[btn.Length];

            //getting the difference in position of the buttons
            for(int i = 0; i < btn.Length; i++)
            {
                if(i != selectedbtn)
                {
                    Vector3 but_pos2 = btn[i].GetComponent<RectTransform>().position;
                    hort_dif[i] = btn_position.x - but_pos2.x;
                    vert_dif[i] = btn_position.y - but_pos2.y;
                }
            }

            float new_vert = 9999;
            float new_hort = 9999;

            if((Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S) && !buttonpressed))
            {
                buttonpressed = true;

                for(int i = 0; i < btn.Length; i++)
                {
                    if(i != selectedbtn) //dont test for selected button
                    {
                        if (vert_dif[i] > 0) // check for correct direction
                        {
                            if (Mathf.Abs(hort_dif[i]) < Mathf.Abs(new_hort))//find closest button in direction
                            {
                                new_hort = hort_dif[i];
                                if (Mathf.Abs(vert_dif[i]) < new_vert)
                                {
                                    new_vert = vert_dif[i];
                                    selectedbtn = i;
                                }
                                else { selectedbtn = i; }
                            }
                            
                        }
                    }
                }
            }
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && !buttonpressed))
            {
                buttonpressed = true;

                for (int i = 0; i < btn.Length; i++)
                {
                    if (i != selectedbtn) //dont test for selected button
                    {
                        if (vert_dif[i] < 0) // check for correct direction
                        {
                            if (Mathf.Abs(hort_dif[i]) <= Mathf.Abs(new_hort))//find closest button in direction
                            {
                                new_hort = hort_dif[i];
                                if (Mathf.Abs(vert_dif[i]) <= new_vert)
                                {
                                    new_vert = vert_dif[i];
                                    selectedbtn = i;
                                }
                                else { selectedbtn = i; }
                            }

                        }
                    }
                }
            }
            if(horizontal ==0 && vertical ==0)
            {
                buttonpressed = false;
            }
        }
        else selectedbtn = 0;
    }
}
