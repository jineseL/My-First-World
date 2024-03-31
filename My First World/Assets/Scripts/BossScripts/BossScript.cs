using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int BossHealth;
    private bool isinv;
    private bool bossdefeated=false;

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

    //to disable
    private GameObject[] Enemies;
    public GameObject handspawner1,handspawner2,handspawner3,healthbarsprite;

    private float explosiontimer;
    public GameObject explosions1, explosions2, explosions3, explosions4, explosions5, explosions6, explosions7;
    public bool bossdead;

    public GameObject gamecamera;


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
            //Destroy(gameObject);
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

        //retarded way of doing explosions timer
        if (bossdefeated == true)
        {
            gamecamera.GetComponent<Animator>().SetBool("SideToSide", true);
            explosiontimer += Time.deltaTime;

            /*if(explosiontimer > 4.3f)
            {
                tinyboss.SetActive(true);
                portal.SetActive(true);
                bossdefeated = false;
            }*/
            if (explosiontimer > 4f)
            {
                //if anyone is seeing this im sorry, im running out of time and this is the fastest
                //way i could think of to do this.
                Instantiate(maskbreak, explosions1.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions2.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions3.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions4.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions5.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions6.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions7.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions1.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions2.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions3.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions4.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions5.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions6.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions7.transform.position, transform.rotation);
                bossdefeated = false;
                bossdead = true;
                gamecamera.GetComponent<Animator>().SetBool("SideToSide", false);
                Destroy(gameObject);
            }
            else if (explosiontimer > 3.7f && explosiontimer < 3.8f)
            {
                Instantiate(maskbreak, explosions4.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions6.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions3.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions1.transform.position, transform.rotation);
            }
            else if (explosiontimer > 3.2 && explosiontimer < 3.3f)
            {
                Instantiate(maskbreak, explosions5.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions7.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions3.transform.position, transform.rotation);
            }
            else if (explosiontimer > 2.8f && explosiontimer < 2.9f)
            {
                Instantiate(maskbreak, explosions1.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions4.transform.position, transform.rotation);
            }
            else if (explosiontimer > 2.2f && explosiontimer < 2.3f)
            {
                Instantiate(maskbreak, explosions2.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions5.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions6.transform.position, transform.rotation);
            }
            else if (explosiontimer > 2.2f && explosiontimer < 2.3f)
            {
                Instantiate(maskbreak, explosions3.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions5.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions4.transform.position, transform.rotation);
            }
            else if(explosiontimer > 1.5f && explosiontimer < 1.6f)
            {
                Instantiate(maskbreak, explosions1.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions7.transform.position, transform.rotation);
            }
            else if (explosiontimer > 1f && explosiontimer < 1.1f)
            {
                Instantiate(maskbreak, explosions6.transform.position, transform.rotation);
                Instantiate(maskbreak, explosions2.transform.position, transform.rotation);
            }
            else if (explosiontimer > 0.5f && explosiontimer < 0.6f)
            {
                Instantiate(maskbreak, explosions3.transform.position, transform.rotation);
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
        //Time.timeScale = 0;
        //victoryscreen.SetActive(true);
        bossdefeated = true;
        destroyallenemies();
        handspawner1.SetActive(false);
        handspawner2.SetActive(false);
        handspawner3.SetActive(false);
        healthbarsprite.SetActive(false);
    }
    private void destroyallenemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i] != null)
            {
                Instantiate(maskbreak, Enemies[i].transform.position, Enemies[i].transform.rotation);
                Destroy(Enemies[i]);
            }
        }
    }
}
