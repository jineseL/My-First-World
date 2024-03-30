using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public VideoPlayer video;
    void Start()
    {
        video.Play();
        video.loopPointReached += gotonextscene;
    }
    private void gotonextscene(VideoPlayer video)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
