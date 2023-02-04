using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField]
    private GameObject _target;
    private List<GameObject> targetList;
    private Vector3 _lastKnownPos;
    Quaternion _lookatRot;
    private ShootingSystem _shootSystem;
    // Start is called before the first frame update
    void Start()
    {
        targetList = new List<GameObject>();
        _shootSystem = GetComponent<ShootingSystem>();
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
        _shootSystem.SetTarget(_target);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //Debug.Log("Hoi");
            targetList.Add(other.gameObject);
            EnemyScript enemyScript = other.gameObject.GetComponent<EnemyScript>();
            enemyScript.AddListener(DestroyEnemy);
            if(!_target)
            {
                SetTarget(other.gameObject);
            }
        }
    }

    private void DestroyEnemy(GameObject pGameObject)
    {
        targetList.Remove(pGameObject);
        Destroy(pGameObject);
        _shootSystem.SetTarget(null);
        if(targetList.Count != 0)
        {
            SetTarget(targetList[0]);
        }
    }
}
