using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private int _health = 10;

    UnityEvent<GameObject> _enemyDead;

    [SerializeField]
    private Transform _target;

    private int _moveSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        _enemyDead = new UnityEvent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    public void AddListener(UnityAction<GameObject> pCall)
    {
        _enemyDead.AddListener(pCall);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BaseProjectile bullet = collision.gameObject.GetComponent<BaseProjectile>();
        if(bullet != null)
        {
            _health -= bullet.GetDamage();

            if(_health < 0)
            {
                _enemyDead.Invoke(this.gameObject);
            }
        }
    }

    public void SetTarget(Transform pTarget)
    {
        _target = pTarget;
    }
}
