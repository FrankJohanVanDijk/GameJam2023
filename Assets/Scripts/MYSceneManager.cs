using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MYSceneManager : MonoBehaviour
{
    public void GoToIslandTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToIsland()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
