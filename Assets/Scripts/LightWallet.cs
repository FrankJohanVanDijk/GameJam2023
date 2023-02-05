using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightWallet : Singleton<LightWallet>
{
    [SerializeField]
    float _lightAmount = 0;

    public UnityEvent walletAmountChanged;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLight(float pLight)
    {
        _lightAmount += pLight;
        walletAmountChanged.Invoke();
    }

    public void RemoveLight(float pLight)
    {
        _lightAmount -= pLight;
        walletAmountChanged.Invoke();
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
            audioSource.Play();
            Destroy(lightCollectible.gameObject);
            AddLight(1);
        }
    }
}
