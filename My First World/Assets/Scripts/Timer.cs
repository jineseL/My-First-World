using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timertext;
    [SerializeField]
    float timer;
    public GameObject player;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            player.GetComponent<PlayerHealth>().death();
            timertext.text = string.Format("{0:00}:{1:00}", 0, 0);
        }
    }
}
