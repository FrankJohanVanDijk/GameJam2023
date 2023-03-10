using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUIManager : MonoBehaviour
{
    private TurretWaterSystem[] turretWaterSystems;

    public List<GameObject> turretListScreens;
    public RectTransform prefabTurretUIScreen;
    // Start is called before the first frame update
    void Start()
    {
        turretWaterSystems = GetComponentsInChildren<TurretWaterSystem>();
        Transform uiparent = prefabTurretUIScreen.parent;
        Debug.Log("CHILDS:" + transform.childCount);
        for(int i = 0; i < transform.childCount; i++)
        {
            turretWaterSystems[i].SetIndex(i + 1);
            GameObject go = Instantiate(prefabTurretUIScreen.gameObject, uiparent);
            go.GetComponent<TurretUI>().index = i;
            if(i > 2)
            {
                turretWaterSystems[i].transform.parent.gameObject.SetActive(false);
                go.SetActive(false);
            }
            turretListScreens.Add(go);
        }

        SuperGameManager.instance.RegisterUpgradeScreens(turretListScreens);
    }


    public void EnableMoreTurrets()
    {
        for(int i = 3; i < transform.childCount; i++)
        {
            turretWaterSystems[i].transform.parent.gameObject.SetActive(true);
        }
    }

    public void DoubleDamage(int pIndex)
    {
        turretWaterSystems[pIndex].DoubleDamage();
    }

    public void DoubleTurnSpeed(int pIndex)
    {
        turretWaterSystems[pIndex].DoubleTurnSpeed();
    }

    public void DoubleFireRate(int pIndex)
    {
        turretWaterSystems[pIndex].DoubleFireRate();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
