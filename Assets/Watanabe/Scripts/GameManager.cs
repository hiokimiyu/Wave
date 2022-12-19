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
    [Tooltip("攻撃のレベル")]
    [SerializeField] private AttackTypes _attackRange;

    /// <summary> クリアウェーブ数 </summary>
    private int _waveCount = 0;
    /// <summary> スポナーのタグ </summary>
    private readonly string _spawnerTag = "Spawner";
    /// <summary> クリア判定をリザルトシーンに伝えるbool </summary>
    private static bool _isClear = false;
    /// <summary> フェードイン、アウトのクラス </summary>
    private Fade _fade;

    /// <summary> 敵をまとめた親オブジェクト </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> クリア判定をリザルトシーンに伝えるbool </summary>
    public static bool IsClear { get => _isClear; set => _isClear = value; }

    // Start is called before the first frame update
    void Start()
    {
        _fade = GetComponent<Fade>();
        _isClear = false;
        _attackRange.RangeLV = 0;

        //各Listにシーン上の該当要素を追加する(最初に既に敵が存在している場合)
        //↓敵
        if (_enemyParent.transform.childCount > 0)
        {
            foreach (Transform child in _enemyParent.GetComponentInChildren<Transform>())
            {
                _sceneEnemies.Add(child.gameObject);
            }
        }
        //↓スポナー
        if (_spawnerParent.transform.childCount > 0)
        {
            foreach (Transform child in _spawnerParent.GetComponentInChildren<Transform>())
            {
                if (child.gameObject.CompareTag(_spawnerTag))
                {
                    _spawner.Add(child.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
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
