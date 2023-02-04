using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonCode : MonoBehaviour
{
    public int lightCost = 5;
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        LightWallet.instance.walletAmountChanged.AddListener(CheckPurchable);
        _button.onClick.AddListener(ExcutePurschase);
    }

    void CheckPurchable()
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }
        if (LightWallet.instance.GetLight() < lightCost)
        {
            
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
    }

    private void OnEnable()
    {
        CheckPurchable();
    }

    public void ExcutePurschase()
    {
        LightWallet.instance.RemoveLight(lightCost);
    }
}
