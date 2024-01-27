using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int currentMoney;
    [SerializeField] TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText.SetText("$" + currentMoney.ToString());
    }
    public void CollectMoney(int _amount)
    {
        currentMoney += _amount;
        moneyText.SetText("$"+currentMoney.ToString());   
    }
}
