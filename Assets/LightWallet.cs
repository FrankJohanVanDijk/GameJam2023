using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWallet : MonoBehaviour
{
    [SerializeField]
    float _lightAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLight(float pLight)
    {
        _lightAmount += pLight;
    }

    public void RemoveLight(float pLight)
    {
        _lightAmount -= pLight;
    }

    public float GetLight()
    {
        return _lightAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        LightCollectible lightCollectible = collision.collider.gameObject.GetComponent<LightCollectible>();
        if(lightCollectible != null)
        {
            Destroy(lightCollectible.gameObject);
            AddLight(1);
        }
    }
}
