using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{

    [SerializeField] AudioClip music;
    AudioSource musicSource;

    private static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        musicSource = GetComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.Play();
    }
}
