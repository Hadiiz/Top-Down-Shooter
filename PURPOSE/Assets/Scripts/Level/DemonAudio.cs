using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    void PlayExplosion()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
}
