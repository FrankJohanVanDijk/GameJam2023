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

    int _index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        shootingSystem = transform.parent.gameObject.GetComponent<ShootingSystem>();
        trackingSystem = transform.parent.gameObject.GetComponent<TrackingSystem>();
        _playerWaterTank = _player.GetComponent<WaterTank>();
        _ownWaterTank = transform.parent.gameObject.GetComponent<WaterTank>();
        Debug.Log("END: " + _ownWaterTank);
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInRange)
        {
            if(_playerWaterTank.GetWaterAmount() > 1 && !_ownWaterTank.ISFULL())
            {
                float waterToAdd = waterMultiplier * Time.deltaTime;
                _ownWaterTank.AddWater(waterToAdd);
                _playerWaterTank.LoseWater(waterToAdd);
            }
        }

        if(_ownWaterTank.GetWaterAmount() < 1)
        {
            //Debug.Log("Disable");
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

    public void SetIndex(int pIndex)
    {
        _index = pIndex;
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

    private void OnMouseDown()
    {
        Debug.Log("INDEX: " + _index);
        SuperGameManager.instance.OpenMenu(_index);
    }

    public void DoubleDamage()
    {
        shootingSystem.damage *= 2;
    }

    public void DoubleFireRate()
    {
        shootingSystem.fireRate /= 2;
        shootingSystem.waterCostBullet /= 2;
    }

    public void DoubleTurnSpeed()
    {
        trackingSystem.speed *= 2;
    }
}
