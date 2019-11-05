using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    void PlayExplosion()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayHurt()
    {
        int index = Random.Range(1, 4);
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
