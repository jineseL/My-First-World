using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timertext;
    float timer;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timertext.text = timer.ToString();
    }
}
