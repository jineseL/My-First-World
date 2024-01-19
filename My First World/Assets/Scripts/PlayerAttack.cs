using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //for attacking
    public GameObject attackAreaRight = default;
    public GameObject attackAreaLeft = default;
    private bool attacking = false;
    private float attackSpeed;
    private float timer;
    void Start()
    {
        attackAreaRight.SetActive(attacking);
        attackAreaLeft.SetActive(attacking);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attacking();
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
        else if(gameObject.transform.GetComponentInParent<PlayerMovement>().isfacingright == false)
        {
            attackAreaLeft.SetActive(attacking);
        }

    }
}
