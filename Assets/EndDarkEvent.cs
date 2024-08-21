using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDarkEvent : MonoBehaviour
{
    [SerializeField] GameObject FinalSuccessPanel;
    bool isFinished =false;


    private void Update()
    {
        if (isFinished && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void OnAnimationFinish()
    {
        isFinished = true;
        FinalSuccessPanel.SetActive(true);
        Time.timeScale = 0;
    }

}
