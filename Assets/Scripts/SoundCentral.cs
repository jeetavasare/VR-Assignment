using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCentral : MonoBehaviour
{
    public AudioClip []zombieHurts;
    public AudioClip []zombieDeath;
    //public AudioClip []zombieSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static AudioClip PlayRandomSound(List<AudioClip> soundList)
    {
        if (soundList.Count > 0)
        {
            int randomIndex = Random.Range(0, soundList.Count);
            //audioSource.clip = soundList[randomIndex]; // Select a random audio clip
            return soundList[randomIndex];
        }
        else
        {
            Debug.LogWarning("Sound list is empty!"); // Warning if the sound list is empty
            return null;
        }
    }
}
