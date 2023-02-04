using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SuperGameManager : Singleton<SuperGameManager>
{
    public PlayerScript playerScript;
    public GameObject mainUpgradeScreen;
    public List<GameObject> turretListScreens;

    private GameObject currentScreen;

    public UnityEvent<int> upgradebleClicked;

    public UnityEvent menuClosed;

    public Canvas MainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mainUpgradeScreen.gameObject.SetActive(false);
        upgradebleClicked.AddListener(OpenMenu);
        menuClosed.AddListener(CloseMenu);
    }

    public void RegisterUpgradeScreens(List<GameObject> gameObjects)
    {
        gameObjects.Insert(0, mainUpgradeScreen);
        turretListScreens = gameObjects;
    }

    public void OpenMenu(int pIndex)
    {
        if(pIndex == 0)
        {
            currentScreen = mainUpgradeScreen;
        }
        else
        {
            currentScreen = turretListScreens[pIndex];
        }

        currentScreen.gameObject.SetActive(true);
        playerScript.enabled = false;
    }

    public void CloseMenu()
    {
        currentScreen.gameObject.SetActive(false);
        playerScript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
