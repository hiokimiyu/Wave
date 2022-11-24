using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �w�肵��Audio���Đ�����N���X
/// </summary>
public class SoundManager : MonoBehaviour
{
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
