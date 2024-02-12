using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //for attacking
    public GameObject attackAreaRight = default;
    public GameObject attackAreaLeft = default;
    private bool attacking = false;
    public float attackSpeed; // more like attac duration actually
    private float timer;
    private Animator m_Animator;
    void Start()
    {
        //to set both attack area inactive 
        m_Animator = GetComponentInParent<Animator>();
        attackAreaRight.SetActive(attacking);
        attackAreaLeft.SetActive(attacking);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //only activate attack area when left click is press
        {
            Attacking();
            m_Animator.SetTrigger("Punch");
        }
        if (attacking)
        {
            
            timer += Time.deltaTime;
            if(timer>= attackSpeed)
            {
                timer = 0;
                attacking = false;
                attackAreaLeft.SetActive(attacking);
                attackAreaRight.SetActive(attacking);
                
            }
        }
    }
    private void Attacking()
    {
        attacking = true;
        if (gameObject.transform.GetComponent<PlayerMovement>().isfacingright == true)
        {
            attackAreaRight.SetActive(attacking);
        }
        else if(gameObject.transform.GetComponent<PlayerMovement>().isfacingright == false)
        {
            attackAreaLeft.SetActive(attacking);
        }

    }
}
