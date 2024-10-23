using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathSound : MonoBehaviour
{
    private static ZombieDeathSound instance; 
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeath()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public static void PlayDeathSound()
    {
        if (instance != null && instance.audioSource != null)
        {
            instance.audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource is not initialized. Make sure to call this after the object is created.");
        }
    }
}
