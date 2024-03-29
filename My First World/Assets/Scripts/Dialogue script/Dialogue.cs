using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public enum emotionstate
    {
        Neutral,
        Angry,
        Confuse,
        Emotion4
    }

    public string name;
    [TextArea(3,10)] // to make the dialogue boxes in game object be bigger
    public string[] sentences;
    public emotionstate[] emotions;
    public bool options;
    
}
