using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudioScript : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void playAudioFootStep()
    {
        audioSource.Play();
        audioSource.pitch = Random.Range(0.70f, 1f);
    }
}
