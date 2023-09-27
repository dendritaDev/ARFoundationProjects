using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    private string sceneName = "PlanetScene";
    private string menuScene = "HomeScreen";

    public void SwitchScenes()
    {   
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
