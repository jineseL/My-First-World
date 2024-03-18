using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.Play();
        }
    }

}