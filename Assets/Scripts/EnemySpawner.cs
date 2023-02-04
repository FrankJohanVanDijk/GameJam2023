using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    Vector3 axis = new Vector3(0, 1, 0);

    [SerializeField]
    float _rotationSpeed = 15;

    [SerializeField]
    GameObject _enemyToSpawn;

    [SerializeField]
    float spawnRate = 0.8f;

    float _spawnTimer;

    float _startTimer;
    [SerializeField]
    float startSpawnTime = 5;

    bool startSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_target.position, axis, _rotationSpeed * Time.deltaTime);

        if(!startSpawning)
        {
            _startTimer += Time.deltaTime;
            if(_startTimer >= startSpawnTime)
            {
                startSpawning = true;
            }
        }
        else
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= spawnRate)
            {
                GameObject enemy = Instantiate(_enemyToSpawn, this.transform.position, Quaternion.Euler(_target.position - transform.position)) as GameObject;
                enemy.GetComponent<EnemyScript>().SetTarget(_target);
                _spawnTimer = 0;
            }
        }

        
    }
}
