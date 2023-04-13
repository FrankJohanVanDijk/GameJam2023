using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _elapsedTime = 0;
    private Vector3Int _secMinHours = new Vector3Int();

    private bool _isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        _secMinHours.x = 0;
        _secMinHours.y = 0;
        _secMinHours.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isPlaying)
        {
            _elapsedTime += Time.deltaTime;
        }
    }

    public void ResetTimer()
    {
        _elapsedTime = 0;
        _isPlaying = false;
    }

    public void StartTimer()
    {
        _isPlaying = true;
    }

    public void EndTimer()
    {
        _isPlaying = false;
    }

    public Vector3Int GetTheTime()
    {
        _secMinHours.x = (int)(_elapsedTime % 60);
        _secMinHours.y = (int)(_elapsedTime / 60);
        _secMinHours.z = (int)(_elapsedTime / 3600);

        //To not show seconds or minutes above 60
        //_secMinHours.x -= _secMinHours.y * 60;
        //_secMinHours.y -= _secMinHours.z * 60;
        return _secMinHours;
    }
}
