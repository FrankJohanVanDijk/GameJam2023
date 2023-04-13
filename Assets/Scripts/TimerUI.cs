using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;

    [SerializeField]
    private TextMeshProUGUI _hours;
    [SerializeField]
    private TextMeshProUGUI _minutes;
    [SerializeField]
    private TextMeshProUGUI _seconds;

    [SerializeField]
    private bool _updateEachFrame = false;

    
    void Awake()
    {
        if(_timeManager == null)
        {
            Debug.LogError("TimeManager has not been assigned");
        }

        if (_hours == null)
        {
            Debug.LogError("Hours has not been assigned");
        }

        if (_minutes == null)
        {
            Debug.LogError("Minutes has not been assigned");
        }

        if (_seconds == null)
        {
            Debug.LogError("Seconds has not been assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_updateEachFrame)
        {
            UpdateText();
        }
    }

    public void UpdateText()
    {
        Vector3Int time = _timeManager.GetTheTime();
        string preCharacter = "";

        if (time.x < 10)
        {
            preCharacter = "0";
        }
        _seconds.text = preCharacter + time.x.ToString();
        preCharacter = "";

        if (time.y < 10)
        {
            preCharacter = "0";
        }
        _minutes.text = preCharacter + time.y.ToString() + ":";
        preCharacter = "";

        if (time.z < 10)
        {
            preCharacter = "0";
        }
        _hours.text = preCharacter + time.z.ToString() + ":";
    }
}
