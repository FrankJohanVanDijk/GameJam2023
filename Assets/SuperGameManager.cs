using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SuperGameManager : Singleton<SuperGameManager>
{
    public PlayerScript playerScript;
    public RectTransform mainUpgradeScreen;
    public List<RectTransform> turretListScreens;

    private RectTransform currentScreen;

    public UnityEvent<int> upgradebleClicked;

    public UnityEvent menuClosed;

    // Start is called before the first frame update
    void Start()
    {
        mainUpgradeScreen.gameObject.SetActive(false);
        upgradebleClicked.AddListener(OpenMenu);
        menuClosed.AddListener(CloseMenu);
    }

    public void RegisterUpgradeScreens()
    {

    }

    public void OpenMenu(int pIndex)
    {
        if(pIndex == 0)
        {
            currentScreen = mainUpgradeScreen;
        }
        else
        {
            currentScreen = turretListScreens[pIndex - 1];
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
