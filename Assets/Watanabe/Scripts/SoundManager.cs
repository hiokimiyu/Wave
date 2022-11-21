using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// w’è‚µ‚½Audio‚ğÄ¶‚·‚é
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary> Ä¶—p‚ÌAudioSource </summary>
    AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// w’è‚µ‚½‰¹‚ğÄ¶‚·‚é
    /// </summary>
    /// <param name="audio"> —¬‚ê‚é‰¹ </param>
    public void AudioPlay(AudioClip audio)
    {
        _source.clip = audio;
        _source.Play();
    }
}
