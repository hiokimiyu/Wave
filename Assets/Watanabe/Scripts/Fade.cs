using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �t�F�[�h�C���A�A�E�g�A�V�[���J��
/// </summary>
public class Fade : MonoBehaviour
{
    [Tooltip("�t�F�[�h�p��UI")]
    [SerializeField] Image _fadePanel;
    [Tooltip("�J�ڐ�̃V�[����")]
    [SerializeField, SceneName] string _sceneName;

    private void Start()
    {
        StartCoroutine(FadeIn(0, 1.5f));
    }

    /// <summary>
    /// Inspector�Ŏw�肷��t�F�[�h�J�n����
    /// </summary>
    public void FadeStart()
    {
        _fadePanel.raycastTarget = true;
        StartCoroutine(FadeOut(0, 1.5f));
    }

    /// <summary>
    /// �t�F�[�h�C���̏���
    /// (�^�����ȃp�l���̃��l[�����x]�����X�ɉ�����)
    /// </summary>
    /// <param name="fadeTime"> ���s���Ԃ̃J�E���g </param>
    /// <param name="interval"> ���l�̕ω��l, �����̎��s���� </param>
    /// <returns></returns>
    IEnumerator FadeIn(float fadeTime, float interval)
    {
        Color color = _fadePanel.color;
        color.a = 1f;
        _fadePanel.color = color;

        //do...���L�̏�����K��1��͎��s����
        do
        {
            yield return null;
            fadeTime += Time.unscaledDeltaTime;
            color.a = 1f - (fadeTime / interval);
            _fadePanel.color = color;

            if (color.a <= 0f)
            {
                color.a = 0f;
            }
            _fadePanel.color = color;
        }
        //while...��L�̏��������s�����������(true�̊Ԏ��s�����)
        while (fadeTime <= interval);
        //��L�̏����̌�Ɏ��s����������������ꍇ�A�ȉ��ɋL�q����
        //Panel��RaycastTarget��false�ɂ���(����Button���N���b�N�ł���悤��)
        _fadePanel.raycastTarget = false;
    }

    /// <summary>
    /// �t�F�[�h�C���̏���
    /// (�^�����ȃp�l���̃��l[�����x]�����X�ɉ�����)
    /// </summary>
    /// <param name="fadeTime"> ���s���Ԃ̃J�E���g </param>
    /// <param name="interval"> ���l�̕ω��l, �����̎��s���� </param>
    /// <returns></returns>
    IEnumerator FadeOut(float fadeTime, float interval)
    {
        Color color = _fadePanel.color;
        color.a = 0f;
        _fadePanel.color = color;

        do
        {
            yield return null;
            fadeTime += Time.unscaledDeltaTime;
            color.a = fadeTime / interval;
            _fadePanel.color = color;

            if (color.a >= 1f)
            {
                color.a = 1f;
            }
            _fadePanel.color = color;
        }
        while (fadeTime <= interval);
        //�t�F�[�h�A�E�g���I�������A�V�[����J�ڂ���
        SceneManager.LoadScene(_sceneName);
    }
}
