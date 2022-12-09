using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// フェードイン、アウト、シーン遷移
/// </summary>
public class Fade : MonoBehaviour
{
    [Tooltip("フェード用のUI")]
    [SerializeField] private Image _fadePanel;

    /// <summary> 遷移先のシーン名 </summary>
    private readonly string _sceneName = "Result";

    private void Start()
    {
        StartCoroutine(FadeIn(0, 1.5f));
    }

    /// <summary>
    /// Inspectorで指定するフェード開始処理
    /// </summary>
    public void FadeStart()
    {
        _fadePanel.raycastTarget = true;
        StartCoroutine(FadeOut(0, 1.5f));
    }

    /// <summary>
    /// フェードインの処理
    /// (真っ黒なパネルのα値[透明度]を徐々に下げる)
    /// </summary>
    /// <param name="fadeTime"> 実行時間のカウント </param>
    /// <param name="interval"> α値の変化値, 処理の実行時間 </param>
    /// <returns></returns>
    IEnumerator FadeIn(float fadeTime, float interval)
    {
        Color color = _fadePanel.color;
        color.a = 1f;
        _fadePanel.color = color;

        //do...下記の処理を(条件の真偽に関わらず)必ず1回は実行する
        do
        {
            yield return null;
            fadeTime += Time.deltaTime;
            color.a = 1f - (fadeTime / interval);
            _fadePanel.color = color;

            if (color.a <= 0f)
            {
                color.a = 0f;
            }
            _fadePanel.color = color;
        }
        //while...上記の処理を実行し続ける条件(trueの間実行される)
        while (fadeTime <= interval);
        //上記の処理の後に実行したい処理がある場合、以下に記述する
        //PanelのRaycastTargetをfalseにする(奥のButtonをクリックできるように)
        _fadePanel.raycastTarget = false;
    }

    /// <summary>
    /// フェードインの処理
    /// (真っ黒なパネルのα値[透明度]を徐々に下げる)
    /// </summary>
    /// <param name="fadeTime"> 実行時間のカウント </param>
    /// <param name="interval"> α値の変化値, 処理の実行時間 </param>
    /// <returns></returns>
    IEnumerator FadeOut(float fadeTime, float interval)
    {
        Color color = _fadePanel.color;
        color.a = 0f;
        _fadePanel.color = color;

        do
        {
            yield return null;
            fadeTime += Time.deltaTime;
            color.a = fadeTime / interval;
            _fadePanel.color = color;

            if (color.a >= 1f)
            {
                color.a = 1f;
            }
            _fadePanel.color = color;
        }
        while (fadeTime <= interval);
        //フェードアウトが終わったら、シーンを遷移する
        SceneManager.LoadScene(_sceneName);
    }
}
