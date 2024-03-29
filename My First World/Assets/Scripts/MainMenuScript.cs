using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void playsettings()
    {
        //Debug.Log("settings");
        SceneManager.LoadScene("SettingsMenu");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void playmainmenu()
    {
        Debug.Log("nain menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
