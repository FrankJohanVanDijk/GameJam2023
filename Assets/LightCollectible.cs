using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollectible : MonoBehaviour
{
    [SerializeField]
    private float _timeAlive = 10;
    [SerializeField]
    private float _timeToBlink = 5;

    [SerializeField]
    private float _intervalBlink = 0.3f;

    private float _curTime = 0;

    bool nextBlink = false;

    MeshRenderer meshRend;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _curTime += Time.fixedDeltaTime;
        if(_curTime > _timeToBlink)
        {
            meshRend.enabled = !meshRend.enabled;
            _timeToBlink += _intervalBlink;
            _intervalBlink *= 0.95f;
        }

        if(_curTime > _timeAlive)
        {
            Destroy(this.gameObject);
        }
    }
}
