using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("寒波、熱波を切り替えるタイミング")]
    [SerializeField] int _switchTime = 0;

    /// <summary> シーン実行中の時間 </summary>
    float _time = 0f;
    /// <summary> シーン上にいる敵の数 </summary>
    List<int> _sceneEnemies = new List<int>();
    /// <summary> シーン上のスポナーの数 </summary>
    List<int> _spawnerCount = new List<int>();
    /// <summary> ウェーブ数 </summary>
    int _waveCount = 0;

    /// <summary> ウェーブ数 </summary>
    public int WaveCount { get => _waveCount; set => _waveCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        //各Listにシーン上の該当要素を追加する
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _switchTime)
        {
            WaveTemp();
            _time = 0f;
        }
    }

    /// <summary>
    /// 寒波、熱波の切り替え
    /// </summary>
    public void WaveTemp()
    {
        //enumかなにかを設定して、切り替える?
    }
}
