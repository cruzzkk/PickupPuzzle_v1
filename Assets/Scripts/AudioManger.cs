using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public static AudioManger instance;
    [SerializeField]
    AudioClip[] _clips;
    [SerializeField]
    AudioSource _as;
    private void Awake()
    {
        instance = this;
    }

    public void AudioPlay(int i) {
        if (_as.isPlaying) {

            _as.Stop();
        }
        _as.PlayOneShot(_clips[i]);
    }
}
