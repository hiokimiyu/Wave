using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("寒波、熱波を切り替えるタイミング(秒)")]
    [SerializeField, Range(1, 15)] int _switchTime = 0;
    [Tooltip("遷移先のシーン名")]
    [SerializeField, SceneName] string _sceneName;
    [Tooltip("敵をまとめておく親オブジェクト")]
    [SerializeField] GameObject _enemyParent;

    /// <summary> シーン実行中の時間 </summary>
    float _time = 0f;
    /// <summary> シーン上にいる敵 </summary>
    [SerializeField] List<GameObject> _sceneEnemies = new List<GameObject>();
    /// <summary> シーン上のスポナー </summary>
    List<GameObject> _spawner = new List<GameObject>();

    /// <summary> シーン上の敵をまとめた親オブジェクト </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> 寒波か、熱波かの切り替え </summary>
    public WaveMode Type { get; set; }
    /// <summary> ウェーブ数 </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //各Listにシーン上の該当要素を追加する
        foreach (Transform child in EnemyParent.transform)
        {
            _sceneEnemies.Add(child.gameObject);
        }
        Type = WaveMode.Warm;
    }

    // Update is called once per frame
    void Update()
    {
        //一定時間経過したら、寒波、熱波を切り替える
        _time += Time.deltaTime;
        if (_time > _switchTime)
        {
            WaveTemp();
            _time = 0f;
            if (_sceneEnemies.Count != 0)
            {
                Destroy(_sceneEnemies[0]);
                _sceneEnemies.Remove(_sceneEnemies[0]);
            }
        }

        if (_sceneEnemies.Count == 0 && _spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
            SceneManager.LoadScene(_sceneName);
        }
    }

    /// <summary>
    /// 寒波、熱波の切り替え
    /// </summary>
    public void WaveTemp()
    {
        Type = Type == WaveMode.Warm ? WaveMode.Cold : WaveMode.Warm;
    }

    public enum WaveMode
    {
        Warm,
        Cold,
    }
}
