using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPocket : MonoBehaviour
{
    MoneyManager moneyManager;
    Laugher laugher;

    [SerializeField] float pickRange;

    private void Awake()
    {   
        moneyManager = FindAnyObjectByType<MoneyManager>();
        laugher = GetComponent<Laugher>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CheckTheNPC()) 
        {
            laugher.curretnTargetNPC.transform.parent.GetComponent<ControlNPC>().isPicked = true;
            moneyManager.CollectMoney(GetRandomAmount());
        }
    }

    int GetRandomAmount()
    {
        int _firstRand = Random.Range(1, 6);
        int _secRand = 0;
        switch ( _firstRand ) 
        {
            case 1:
                _secRand = Random.Range(1, 8); 
                break;
            case 2:
                _secRand = Random.Range(8, 15);
                break;
            case 3:
                _secRand = Random.Range(15, 21);
                break;
            case 4:
                _secRand = Random.Range(21, 25);
                break;
            case 5:
                _secRand = Random.Range(25, 50);
                break;
        }
        return _secRand;
    }

     bool CheckTheNPC() 
    {
        if (laugher.curretnTargetNPC)
        {
            return laugher.curretnTargetNPC.transform.parent.GetComponent<ControlNPC>().isLaughing && !laugher.curretnTargetNPC.transform.parent.GetComponent<ControlNPC>().isPicked;
        }
        else
        {
            return false;
        }
    }
}
