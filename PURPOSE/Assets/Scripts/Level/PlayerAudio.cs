using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    void PlayTeleport()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    void PlayTeleportBack()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void PlayHurt()
    {
        int index = Random.Range(2, 5);
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
