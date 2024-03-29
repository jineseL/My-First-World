using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //for attacking
    public GameObject attackAreaRight = default;
    //public GameObject attackAreaLeft = default;
    public bool attacking = false;
    public float attackSpeed; // more like attac duration actually
    private float timer;
    private Animator m_Animator;
    public float actualattackspeed;
    private float attackspeedtimer;
    private PlayerMovement playermovementRef;
    void Start()
    {
        //to set both attack area inactive 
        m_Animator = GetComponentInParent<Animator>();
        attackAreaRight.SetActive(attacking);
        playermovementRef = GetComponent<PlayerMovement>();
        //attackAreaLeft.SetActive(attacking);
    }

    // Update is called once per frame
    void Update()
    {
        if (attackspeedtimer < actualattackspeed)
        {
            attackspeedtimer += Time.deltaTime;
        }
        if (playermovementRef.caninput)
        {
            if (Input.GetKeyDown(KeyCode.L)) //only activate attack area when left click is press
            {
                if (attackspeedtimer >= actualattackspeed)
                {
                    if (timer <= attackSpeed)
                    {
                        attackspeedtimer = 0;
                        Attacking();
                        m_Animator.SetTrigger("Punch");
                    }
                }
            }
        }
        if (attacking)
        {
            //Physics2D.IgnoreLayerCollision(6, 10, false);
            timer += Time.deltaTime;
            if(timer>= attackSpeed)
            {
                timer = 0;
                attacking = false;
                //attackAreaLeft.SetActive(attacking);
                attackAreaRight.SetActive(attacking);
                
            }
        }
    }
    private void Attacking()
    {
        attacking = true;
        attackAreaRight.SetActive(attacking);
        /*if (gameObject.transform.GetComponent<PlayerMovement>().isfacingright == true)
        {
            attackAreaRight.SetActive(attacking);
        }
        else if(gameObject.transform.GetComponent<PlayerMovement>().isfacingright == false)
        {
            attackAreaLeft.SetActive(attacking);
        }*/

    }
}
