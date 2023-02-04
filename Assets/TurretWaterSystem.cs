using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWaterSystem : MonoBehaviour
{
    [Range(0, 100)]
    public float startWaterAmount = 20;

    public float maxWaterAmount = 100;

    public float curWaterAmount;

    private ShootingSystem shootingSystem;
    private TrackingSystem trackingSystem;

    // Start is called before the first frame update
    void Start()
    {
        shootingSystem = GetComponent<ShootingSystem>();
        trackingSystem = GetComponent<TrackingSystem>();
        curWaterAmount = startWaterAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(curWaterAmount < 1)
        {
            curWaterAmount = 1;
            shootingSystem.enabled = false;
            trackingSystem.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            //other.GetComponent<WaterTank>();
        }
    }
}
