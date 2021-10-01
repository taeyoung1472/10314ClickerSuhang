using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    bool isSound = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DoQuit();
        }
    }
    public void DoQuit()
    {
        Application.Quit();
    }
    public void SoundOnOff()
    {
        if (isSound)
        {
            AudioListener.volume = 0;
            isSound = false;
        }
        else
        {
            AudioListener.volume = 1;
            isSound = true;
        }
    }
}
