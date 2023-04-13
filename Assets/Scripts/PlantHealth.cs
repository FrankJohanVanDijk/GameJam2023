using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantHealth : MonoBehaviour
{
    int health = 100;

    public UnityEvent healthChanged;
    public UnityEvent healthIsZero;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        //healthChanged = new UnityEvent();
        //healthIsZero = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && !dead)
        {
            Debug.Log("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            //Time.timeScale = 0;
            dead = true;
            healthIsZero.Invoke();
        }
    }

    public void LoseHealth(int pDamage)
    {
        health -= pDamage;
        healthChanged.Invoke();
    }

    public int GetHealth()
    {
        return health;
    }
}
