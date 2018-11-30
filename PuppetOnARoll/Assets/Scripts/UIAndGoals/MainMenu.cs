using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string SceneName;

    public void GotoLevel()
    {
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);  
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
