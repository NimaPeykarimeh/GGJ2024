using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{

    [SerializeField] LayerMask finishLayer;
    [SerializeField] GameObject finishDark;
    FinishGame finishGame;

    private void Awake()
    {
        finishGame = FindAnyObjectByType<FinishGame>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ChechForFinish())
            {
                FinishTheGame();
            }
        }
    }

    void FinishTheGame()
    {
        finishGame.RideTheTruck();
        finishDark.SetActive(true);
    }

    bool ChechForFinish()
    {
        return Physics.CheckSphere(transform.position, 1, finishLayer);
    }

}
