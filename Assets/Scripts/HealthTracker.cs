using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthTracker : MonoBehaviour
{
    public PlantHealth plant;
    private TextMeshProUGUI _text;
    public GameObject gameOverScreen;
    public GameObject mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        plant.healthChanged.AddListener(ChangeText);
        plant.healthIsZero.AddListener(GetGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        //lig
    }

    public void ChangeText()
    {
        _text.text = plant.GetHealth().ToString();
    }

    public void GetGameOver()
    {
        mainCanvas.SetActive(false);
        gameOverScreen.SetActive(true);
        SuperGameManager.instance.PauseGame();
    }
}
