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

    [SerializeField]
    private int _moveSpeed = 4;

    [SerializeField]
    private GameObject _collectibleToSpawn;

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
                Vector3 extraHeight = new Vector3(0, 2, 0);
                GameObject collectible = Instantiate(_collectibleToSpawn, this.transform.position + extraHeight, Quaternion.Euler(_target.position - transform.position)) as GameObject;
                _enemyDead.Invoke(this.gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            PlantHealth plantHealth = collision.gameObject.GetComponent<PlantHealth>();
            plantHealth.LoseHealth(4);
            _enemyDead.Invoke(gameObject);
        }
    }

    public void SetTarget(Transform pTarget)
    {
        _target = pTarget;
    }
}
