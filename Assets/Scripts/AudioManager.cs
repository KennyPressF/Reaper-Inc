using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioClips;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(int clipToPlay)
    {
        audioClips[clipToPlay].Stop();
        audioClips[clipToPlay].Play();
    }
}
