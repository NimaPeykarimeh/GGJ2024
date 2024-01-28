using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int currentMoney;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] GameObject moneyTextEffect;

    private void Start()
    {
        moneyText.SetText("$" + currentMoney.ToString());
    }
    public void CollectMoney(int _amount)
    {
        GameObject _textEffect = Instantiate(moneyTextEffect, moneyText.transform.parent);
        _textEffect.GetComponent<TextMeshProUGUI>().SetText("$" + _amount.ToString());
        currentMoney += _amount;
        moneyText.SetText("$"+currentMoney.ToString());   
    }
}
