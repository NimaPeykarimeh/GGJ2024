using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlNPC : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    SkinnedMeshRenderer skinedMesh;

    Transform canvasTransform;
    public bool isPicked;
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

    [SerializeField] float surpriseTimer;
    [SerializeField] float surpriseDuration = 10f;
    [SerializeField] bool isSurprised;


    [Header("Emotions")]
    [SerializeField] GameObject laughEmotionObject;
    [SerializeField] GameObject surptiseObject;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        canvasTransform = transform.Find("LaughCanvas");
        animator = GetComponent<Animator>();
        laugher= FindObjectOfType<Laugher>();
        laughMeter = transform.Find("LaughCanvas").Find("LaughMeter").gameObject.GetComponent<Image>();
        skinedMesh = transform.Find("SkinnedMesh").GetComponent<SkinnedMeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetRandomMat();
        isPicked = false;
        laughEmotionObject.SetActive(false);
        laughMeter.fillAmount = 0;
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
        audioSource.PlayOneShot(clip);
        laughEmotionObject.SetActive(true);
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
                laughEmotionObject.SetActive(false);
                isPranking = false;
                laugher.npcLaughCount--;
                if (isPicked)
                {
                    Surprise();
                }

                animator.SetBool("IsLaughin", false);
                laughTimer = 0;
                isLaughing = false;
                isBarChanging = false;
            }
            _meterRatio = laughTimer / laughDuration;
            laughMeter.fillAmount = _meterRatio;
        }

        if (isSurprised)
        {
            float _meterRatio;
            surpriseTimer -= Time.deltaTime;
            if (surpriseTimer < 0)
            {
                surpriseTimer = 0;
                isSurprised = false;
                surptiseObject.SetActive(false);
            }
            _meterRatio = surpriseTimer / surpriseDuration;
            laughMeter.fillAmount = _meterRatio;
        }
    }

    void Surprise()
    {
        isSurprised = true;
        surpriseTimer = surpriseDuration;
        surptiseObject.SetActive(true);
    }

    void SwithFace()
    {

        skinedMesh.material = laughMaterial[randomMatIndex];
    }

    public bool Laugh(bool isLaugh, float _jokeDuration)
    {
        bool _result = (!isLaughing && !isPranking) && isLaugh;
        if (!isSurprised)
        {
            if (!isPranking) 
            {
                isBarChanging = true;
                jokeDuration = _jokeDuration;
                jokeTimer = 0;
            }
        }
        isPranking = isLaugh;

        return _result;
    }

}
