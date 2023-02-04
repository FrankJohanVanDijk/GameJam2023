using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float fireRate;
    public float fieldOfView;
    public GameObject projectile;
    public GameObject target;
    public int damage;
    public List<GameObject> projectileSpawns;

    public bool beam;
    List<GameObject> _lastProjectiles = new List<GameObject>();
    float _fireTimer = 0.0f;

    private WaterTank _waterTank;
    public float waterCostBullet = 5;
    // Start is called before the first frame update
    void Start()
    {
        _waterTank = GetComponent<WaterTank>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beam && _lastProjectiles.Count <= 0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

            if (angle < fieldOfView)
            {
                SpawnProjectiles();
            }
        }
        else if(beam && _lastProjectiles.Count > 0)
        {
           float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

           if(angle > fieldOfView)
            {
                while(_lastProjectiles.Count > 0)
                {
                    Destroy(_lastProjectiles[0]);
                    _lastProjectiles.RemoveAt(0);
                }
            }
        }
        else
        {
            _fireTimer += Time.deltaTime;
            if(_fireTimer >= fireRate)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

                if (angle < fieldOfView)
                {
                    SpawnProjectiles();
                    _fireTimer = 0;
                }
            }
        }
    }

    void SpawnProjectiles()
    {
        if(!projectile)
        {
            return;
        }

        //_lastProjectiles.Clear();

        for(int i = 0; i < projectileSpawns.Count; i++)
        {
            if(projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], target, damage);
                _waterTank.LoseWater(waterCostBullet);
                //_lastProjectiles.Add(proj);
            }
        }
    }
}
