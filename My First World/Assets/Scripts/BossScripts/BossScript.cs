using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int BossHealth;
    private bool isinv;

    private float timer;
    public float invTimer;
    public GameObject victoryscreen;

    public HealthBarScript healthbar;

    public GameObject Impact;
    public GameObject maskbreak;
    public GameObject birdspawners;
    public GameObject birdspawners2;

    public bool phase2;
    public bool phase3;
    private bool phase2explosion;
    private bool phase3explosion;

    public GameObject mask1;
    public GameObject mask2;
    public GameObject mask3;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(BossHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(BossHealth == 0)
        {
            Destroy(gameObject);
            victory();
        }
        if(isinv == true)
        {
            if (timer < invTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                isinv = false;
                timer = 0;
            }
        }
        if (BossHealth <= 100)
        {
            mask1.SetActive(false);
            mask2.SetActive(true);
            phase2 = true;
            birdspawners.SetActive(true);
            if (phase2explosion == false)
            {
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                phase2explosion = true;

            }
        }
        if(BossHealth <= 60)
        {
            mask2.SetActive(false);
            mask3.SetActive(true);
            phase2 = false;
            phase3 = true;
            birdspawners2.SetActive(true);
            if (phase3explosion == false)
            {
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                Instantiate(maskbreak, transform.position, transform.rotation);
                phase3explosion = true;
            }
        }

    }
    public void damage(int damagetaken)
    {
        if (isinv == false)
        {
            Instantiate(Impact, transform.position, transform.rotation);
            Instantiate(maskbreak, transform.position, transform.rotation);
            healthbar.Sethealth(BossHealth);
            BossHealth -= damagetaken;
            isinv = true;
        }
    }
    public void victory()
    {
        Time.timeScale = 0;
        victoryscreen.SetActive(true);
    }
    
}
