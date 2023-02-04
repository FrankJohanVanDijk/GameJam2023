using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    [Range(0, 100)]
    public float startWaterAmount = 20;

    public float maxWaterAmount = 100;

    private float curWaterAmount;

    // Start is called before the first frame update
    void Start()
    {
        curWaterAmount = startWaterAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseWater(float pAmount)
    {
        curWaterAmount -= pAmount;
    }

    public void AddWater(float pAmount)
    {
        curWaterAmount += pAmount;
    }

    public float GetWaterAmount()
    {
        return curWaterAmount;
    }
}
