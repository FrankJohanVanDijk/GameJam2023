using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenObject : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("HEllllllo");
        SuperGameManager.instance.upgradebleClicked.Invoke(0);
    }
}
