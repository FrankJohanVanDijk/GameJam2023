using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthTracker : MonoBehaviour
{
    public PlantHealth plant;
    private TextMeshProUGUI _text;
    public GameObject gameOverScreen;
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

    void ChangeText()
    {
        _text.text = plant.GetHealth().ToString();
    }

    void GetGameOver()
    {
        gameOverScreen.SetActive(true);
        SuperGameManager.instance.PauseGame();
    }
}
