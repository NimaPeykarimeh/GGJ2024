using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] TextMeshProUGUI timerText; 
    [SerializeField] float timer;
    bool isTimeOver;
    public GameObject EndScreen;
    public GameObject HUD;
    public float finalTimer = 60f;
    [SerializeField] Color timeOutColor;

    private void Start()
    {
        Time.timeScale = 1;
        isTimeOver = false;
        timer = maxTime;
    }

    private void Update()
    {
        CountDown();

    }

    

    void GameOver()
    {

        EndScreen.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void SetTimer(float timeToSet)
    {
        timer = timeToSet;
        if (timer <= 0)
        {
            timer = 0;
            GameOver();
        }
        int _minValue = (int)Mathf.Floor(timer / 60);
        int _secValue = (int)(timer - (_minValue * 60));
        string _secText;
        if (_secValue < 10)
        {
            _secText = "0" + _secValue.ToString();
        }
        else
        {
            _secText = _secValue.ToString();
        }
        string _text = _minValue.ToString() + ":" + _secText;
        timerText.SetText(_text);
    }

    public void ReduceTime(float amount)
    {
        timer -= amount;
        if (timer <= 0)
        {
            timer = 0;
            GameOver();
        }
        int _minValue = (int)Mathf.Floor(timer / 60);
        int _secValue = (int)(timer - (_minValue * 60));
        string _secText;
        if (_secValue < 10)
        {
            _secText = "0" + _secValue.ToString();
        }
        else
        {
            _secText = _secValue.ToString();
        }
        string _text = _minValue.ToString() + ":" + _secText;
        timerText.SetText(_text);
    }

    public void TimeOver()
    {
        if (!isTimeOver)
        {
            timerText.color = timeOutColor;
            isTimeOver = true;
            SetTimer(finalTimer);

        }
    }

    void CountDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            if (isTimeOver)
            {
                GameOver();
            }
            else
            {
                TimeOver();
            }

        }
        int _minValue = (int)Mathf.Floor(timer / 60);
        int _secValue = (int)(timer - (_minValue * 60));
        string _secText;
        if (_secValue < 10)
        {
            _secText = "0" + _secValue.ToString();
        } 
        else
        {
            _secText = _secValue.ToString();
        }
        string _text = _minValue.ToString() + ":" + _secText;
        timerText.SetText(_text);

    }


}
