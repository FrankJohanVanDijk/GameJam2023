using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjecttile : BaseProjectile
{
    Vector3 _direction;
    bool _fired;

    float timeAlive = 0;

    private void Update()
    {
        if (_fired)
        {
            transform.position += _direction * speed * Time.deltaTime;
            timeAlive += Time.deltaTime;
            if(timeAlive > 5)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public override void FireProjectile(GameObject pLauncher, GameObject pTarget, int pDamage)
    {
        if(pLauncher && pTarget)
        {
            _direction = (pTarget.transform.position - pLauncher.transform.position).normalized;
            _fired = true;
        }
    }
}
