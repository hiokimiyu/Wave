using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定したAudioを再生するクラス
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Tooltip("攻撃関係の音")]
    [SerializeField] AudioClip[] _attackAudios = new AudioClip[6];

    public AudioClip[] AttackAudios { get => _attackAudios; set => _attackAudios = value; }

    /// <summary> 再生用のAudioSource </summary>
    AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 指定した音を再生する
    /// </summary>
    /// <param name="audio"> 再生する音 </param>
    public void AudioPlay(AudioClip audio)
    {
        _source.clip = audio;
        _source.Play();
    }
}
