using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWaterSystem : MonoBehaviour
{
    private WaterTank _ownWaterTank;

    private ShootingSystem shootingSystem;
    private TrackingSystem trackingSystem;

    [SerializeField]
    private GameObject _player;
    private WaterTank _playerWaterTank;

    bool _playerInRange = false;
    public float waterMultiplier = 5;
    // Start is called before the first frame update
    void Start()
    {
        shootingSystem = transform.parent.gameObject.GetComponent<ShootingSystem>();
        trackingSystem = transform.parent.gameObject.GetComponent<TrackingSystem>();
        _playerWaterTank = _player.GetComponent<WaterTank>();
        _ownWaterTank = transform.parent.gameObject.GetComponent<WaterTank>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInRange)
        {
            if(_playerWaterTank.GetWaterAmount() > 1)
            {
                float waterToAdd = waterMultiplier * Time.deltaTime;
                _ownWaterTank.AddWater(waterToAdd);
                _playerWaterTank.LoseWater(waterToAdd);
            }
        }

        if(_ownWaterTank.GetWaterAmount() < 1)
        {
            Debug.Log("Disable");
            //curWaterAmount = 1;
            shootingSystem.enabled = false;
            trackingSystem.enabled = false;
        }

        if(!shootingSystem.enabled)
        {
            if(_ownWaterTank.GetWaterAmount() > 10)
            {
                shootingSystem.enabled = true;
                trackingSystem.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerInRange = false;
        }
    }
}