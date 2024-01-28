using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{
    Laugher laugher;
    MoneyManager moneyManager;

    [SerializeField] LayerMask moneyBagLayer;
    [SerializeField] LayerMask trunkLayer;
    [SerializeField] Transform grabPoint;
    [SerializeField] float grabRange;
    [SerializeField] float trunkLeaveRange;
    GameObject currentGrabObject;
    [SerializeField] GameObject[] moneyBags;
    public bool isGrabing;
    [SerializeField] Transform mainMoneyParent;

    [SerializeField] int moneyToAdd = 250;

    private void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        laugher = GetComponent<Laugher>();
    }

    private void Start()
    {
        moneyBags = GameObject.FindGameObjectsWithTag("MoneyBag");
    }

    private void Update()
    {
        CheckBag();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGrabing)
            {
                LeaveObject();
            }
            else if (CheckIfGrabbale())
            {
                GrabObject();
            }
        }
    }

    void GrabObject()
    {
        isGrabing =true;
        mainMoneyParent = currentGrabObject.transform.parent;
        currentGrabObject.transform.parent = grabPoint;
        currentGrabObject.transform.localPosition = Vector3.zero; 
    }

    void LeaveObject()
    {
        if (CheckForTrunk())
        {
            moneyManager.CollectMoney(moneyToAdd);
            currentGrabObject.layer = 0;
            currentGrabObject.transform.parent = moneyManager.transform;
            Vector3 _currentPos = currentGrabObject.transform.localPosition;
            _currentPos.y = 0.64f;
            currentGrabObject.transform.localPosition = _currentPos;

        }
        if (isGrabing)
        {
            isGrabing = false;
            currentGrabObject.transform.parent = mainMoneyParent;
            Vector3 _currentPos = currentGrabObject.transform.localPosition;
            _currentPos.y = -2.48f;
            currentGrabObject.transform.localPosition = _currentPos;

        }
    }


    bool CheckForTrunk()
    {
        return Physics.CheckSphere(transform.position, trunkLeaveRange, trunkLayer);
        
    }
    bool CheckIfGrabbale()
    {
        if (!laugher.isPranking && currentGrabObject)
        {
            print("aswasd");
            return true;
        }
        return false;
    }

    void CheckBag()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRange, moneyBagLayer);


        if (colliders.Length > 0)
        {
            float _minDist = Mathf.Infinity;
            currentGrabObject = colliders[0].gameObject;


            foreach (Collider _col in colliders)
            {
                float _currentDist = Vector3.Distance(transform.position, _col.transform.position);

                if (_currentDist < _minDist)
                {
                    _minDist = _currentDist;
                    foreach (GameObject _bag in moneyBags)
                    {
                        _bag.GetComponent<MeshRenderer>().materials[1].SetInt("_IsSelected", 0);
                    }
                    currentGrabObject = _col.gameObject;
                    _col.GetComponent<MeshRenderer>().materials[1].SetInt("_IsSelected", 1);
                }
            }

        }
        else
        {
            currentGrabObject = null;
            foreach (GameObject _bag in moneyBags)
            {
                _bag.GetComponent<MeshRenderer>().materials[1].SetInt("_IsSelected", 0);
            }
        }
    }
}
