using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �w�肵��Audio���Đ�����N���X
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Tooltip("�U���֌W�̉�")]
    [SerializeField] AudioClip[] _attackAudios = new AudioClip[6];

    public AudioClip[] AttackAudios { get => _attackAudios; set => _attackAudios = value; }

    /// <summary> �Đ��p��AudioSource </summary>
    AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// �w�肵�������Đ�����
    /// </summary>
    /// <param name="audio"> �Đ����鉹 </param>
    public void AudioPlay(AudioClip audio)
    {
        _source.clip = audio;
        _source.Play();
    }
}