using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //オブジェクトが破壊される時、シーンから消し、Listからも削除する
    //→List.Countのズレを防ぐ
    [Header("敵のオブジェクト")]
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private GameObject _spawnerParent;
    [SerializeField] private List<GameObject> _sceneEnemies = new();
    [SerializeField] private List<GameObject> _spawner = new();

    /// <summary> クリアウェーブ数 </summary>
    private int _waveCount = 0;
    /// <summary> クリア判定をリザルトシーンに伝えるbool </summary>
    private static bool _isClear = false;
    /// <summary> 攻撃のレベル </summary>
    private AttackTypes _attackRange;
    /// <summary> フェードイン、アウト </summary>
    private Fade _fade;

    /// <summary> 敵をまとめた親オブジェクト </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> クリア判定をリザルトシーンに伝えるbool </summary>
    public static bool IsClear { get => _isClear; set => _isClear = value; }

    private void Start()
    {
        _attackRange = GetComponent<AttackTypes>();
        _fade = GetComponent<Fade>();
        _attackRange.RangeLV = 0;
    }

    private void Update()
    {
        if (_sceneEnemies.Count == 0 && _spawner.Count == 0)
        {
            _waveCount++;
            _attackRange.RangeLV++;
            //全てのWaveをクリアしたら、リザルト画面へ遷移
            if (_waveCount == 5)
            {
                _isClear = true;
                _fade.FadeStart();
            }
        }
    }

    /// <summary> GameOver時の処理(シーン遷移等) </summary>
    public void GameOver()
    {
        _isClear = false;
        _fade.FadeStart();
    }
}
