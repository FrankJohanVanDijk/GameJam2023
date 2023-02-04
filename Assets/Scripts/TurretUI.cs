using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public int index;
    public TurretUIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoubleDamage()
    {
        uIManager.DoubleDamage(index);
    }

    public void DoubleTurnSpeed()
    {
        uIManager.DoubleTurnSpeed(index);
    }

    public void DoubleFireRate()
    {
        uIManager.DoubleFireRate(index);
    }
}
