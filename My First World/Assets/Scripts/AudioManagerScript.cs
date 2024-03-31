using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds;
    public bool destroy;

    public static AudioManagerScript instance;
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
            DontDestroyOnLoad(gameObject);
        
       // SceneManager.sceneLoaded += OnSceneLoaded;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        /*if(SceneManager.GetActiveScene().name == "")*/
        Play("Music");

    }
    /*private void Update()
    {
        
    }*/
    /*void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }*/

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound" + name + "not found");
            return;
        }
        s.source.Play();

    }
}
