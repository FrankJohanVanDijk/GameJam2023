using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletTracker : MonoBehaviour
{
    public LightWallet lightWallet;
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        lightWallet.walletAmountChanged.AddListener(ChangeText);
    }

    // Update is called once per frame
    void Update()
    {
        //lig
    }

    void ChangeText()
    {
        _text.text = lightWallet.GetLight().ToString();
    }
}
