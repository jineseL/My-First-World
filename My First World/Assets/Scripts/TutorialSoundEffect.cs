using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            audioSource.Play();
        }
    }

}