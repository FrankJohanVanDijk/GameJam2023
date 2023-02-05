using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    [Range(0, 100)]
    public float startWaterAmount = 20;

    public float maxWaterAmount = 100;

    private float curWaterAmount;

    [SerializeField]
    private GameObject waterSize;
    private float beginScale = 0.01f;
    Vector3 waterScale;
    // Start is called before the first frame update
    void Start()
    {
        curWaterAmount = startWaterAmount;
        beginScale = waterSize.transform.localScale.y;
        waterScale = waterSize.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        waterScale.y = Mathf.Lerp(0, beginScale, curWaterAmount / maxWaterAmount);
        waterSize.transform.localScale = waterScale;
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

    public bool ISFULL()
    {
        return (curWaterAmount >= maxWaterAmount);
    }

    public void DoubleTank()
    {
        //beginScale *= 2;
        //waterScale.y *= 2;
        //waterSize.transform.localScale = waterScale;
        curWaterAmount *= 2;
        maxWaterAmount *= 2;
    }
}
