using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class ControlNPC : MonoBehaviour
{
    Animator animator;
    SkinnedMeshRenderer skinedMesh;

    Transform canvasTransform;
    public Laugher laugher;
    public bool isPranking;
    public bool isLaughing;
    bool isBarChanging;

    [SerializeField] float laughDuration = 60f;
    [SerializeField] float laughTimer;

    [SerializeField] float jokeDuration = 3f;
    [SerializeField] float jokeTimer;
    Image laughMeter;

    [Header("Materials")]
    int randomMatIndex;
    [SerializeField] Material[] laughMaterial;
    [SerializeField] Material[] regularFacesMaterial;
    Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        canvasTransform = transform.Find("Canvas");
        animator = GetComponent<Animator>();
        laugher= FindObjectOfType<Laugher>();
        laughMeter = transform.Find("Canvas").Find("LaughMeter").gameObject.GetComponent<Image>();
        skinedMesh = transform.Find("SkinnedMesh").GetComponent<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        SetRandomMat();
    }

    void CanvasToCamera()
    {
        canvasTransform.LookAt(cameraTransform.position);
    }

    void SetRandomMat()
    {
        randomMatIndex = Random.Range(0, laughMaterial.Length);
        skinedMesh.material = regularFacesMaterial[randomMatIndex];
    }

    void LookAtPlayer()
    {
        Vector3 _dir = laugher.transform.position - transform.position;
        _dir.y = 0;
        transform.forward = _dir;
    }

    void LaughActivated()
    {
        isLaughing = true;

        laugher.NpcLaughed();
        animator.SetBool("IsLaughin", true);
        SwithFace();
        laugher.isPranking = false;
        laughTimer = laughDuration;
    }

    private void Update()
    {
        CanvasToCamera();
        if (isBarChanging && !isLaughing)
        {
            if (isPranking)
            {
                float _meterRatio;
                jokeTimer += Time.deltaTime;

                LookAtPlayer();

                if (jokeTimer > jokeDuration)
                {
                    LaughActivated();
                }
                _meterRatio = jokeTimer / jokeDuration;
                laughMeter.fillAmount = _meterRatio;
            }
            else
            {
                jokeTimer -= Time.deltaTime;
                if (jokeTimer < 0)
                {
                    jokeTimer = 0;
                    isBarChanging = false;
                }
                float _meterRatio;
                _meterRatio = jokeTimer / jokeDuration;
                laughMeter.fillAmount = _meterRatio;
            }
        }
        if (isLaughing)
        {
            float _meterRatio;
            laughTimer -= Time.deltaTime;
            if (laughTimer <0)
            {
                jokeTimer = 0;
                animator.SetBool("IsLaughin", false);
                laughTimer = 0;
                isLaughing = false;
                isBarChanging = false;
            }
            _meterRatio = laughTimer / laughDuration;
            laughMeter.fillAmount = _meterRatio;
        }
    }

    void SwithFace()
    {
        skinedMesh.material = laughMaterial[randomMatIndex];
    }

    public void Laugh(bool isLaugh, float _jokeDuration)
    {
        isBarChanging = true;
        jokeDuration = _jokeDuration;
        jokeTimer = 0;
        isPranking = isLaugh;
    }

}
