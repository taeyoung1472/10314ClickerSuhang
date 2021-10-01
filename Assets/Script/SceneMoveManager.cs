using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    

    public void GoMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
