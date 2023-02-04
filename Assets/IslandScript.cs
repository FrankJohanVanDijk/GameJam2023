using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private WaterTank _playerWaterTank;

    private bool _inWater;

    public float waterMultiplier = 60;

    // Start is called before the first frame update
    void Start()
    {
        _playerWaterTank = _player.GetComponent<WaterTank>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_inWater)
        {
            _playerWaterTank.AddWater(waterMultiplier * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player == other.gameObject)
        {
            _inWater = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_player == other.gameObject)
        {
            _inWater = true;
        }
    }
}
