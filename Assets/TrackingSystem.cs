using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField]
    private GameObject _target;
    private Vector3 _lastKnownPos;
    Quaternion _lookatRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_target)
        {
            if (_lastKnownPos != _target.transform.position)
            {
                _lastKnownPos = _target.transform.position;
                _lookatRot = Quaternion.LookRotation(_lastKnownPos - transform.position);
            }

            if (transform.rotation != _lookatRot)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookatRot, speed * Time.deltaTime);
        }
        
    }

    bool SetTarget(GameObject pTarget)
    {
        if(!pTarget)
        {
            return false;
        }

        _target = pTarget;

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {

        }
    }
}
