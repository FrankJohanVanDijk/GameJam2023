using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TimerUI timerUI;

    public void OnEnable()
    {
        if (timerUI != null)
            timerUI.UpdateText();
        else
            Debug.LogError("No TimerUI!!!");
    }
}
