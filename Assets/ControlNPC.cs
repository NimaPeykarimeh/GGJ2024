using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlNPC : MonoBehaviour
{
    public Laugher laugher;
    public bool isPranking;
    public bool isLaughing;
    bool isBarChanging;

    [SerializeField] float laughDuration = 3f;
    [SerializeField] float laughTimer;
    Image laughMeter;


    private void Awake()
    {
        laugher= FindObjectOfType<Laugher>();
        laughMeter = transform.Find("Canvas").Find("LaughMeter").gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (isBarChanging && !isLaughing)
        {
            if (isPranking)
            {
                float _meterRatio;
                laughTimer += Time.deltaTime;
                if (laughTimer> laughDuration)
                {
                    laughTimer = laughDuration;
                    isBarChanging = false;
                    isLaughing = true;
                    laugher.isPranking = false;
                }
                _meterRatio = laughTimer / laughDuration;
                laughMeter.fillAmount = _meterRatio;
            }
            else
            {
                laughTimer -= Time.deltaTime;
                if (laughTimer < 0)
                {
                    laughTimer = 0;
                    isBarChanging = false;
                }
                float _meterRatio;
                _meterRatio = laughTimer / laughDuration;
                laughMeter.fillAmount = _meterRatio;
            }

        }
    }

    public void Laugh(bool isLaugh)
    {
        isBarChanging = true;
        isPranking = isLaugh;
    }

}
