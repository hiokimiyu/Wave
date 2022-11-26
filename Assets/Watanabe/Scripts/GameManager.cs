using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //オブジェクトが破壊される時、シーンから消し、Listからも削除する
    //→List.Countのズレを防ぐ
    [Tooltip("敵をまとめておく親オブジェクト")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("スポナーをまとめておく親オブジェクト")]
    [SerializeField] GameObject _spawnerParent;
    [Tooltip("敵をまとめるList")]
    [SerializeField] List<GameObject> _sceneEnemies = new();
    [Tooltip("スポナーをまとめるList")]
    [SerializeField] List<GameObject> _spawner = new();
    [Tooltip("ウェーブのレベル")]
    [SerializeField] PlayerShot _player;
    [Tooltip("現在の攻撃の状態を表示するUI")]
    [SerializeField] Text _attackTypeText;
    [Tooltip("SpawnerのTag")]
    [SerializeField, TagName] string _spawnerTag;

    /// <summary> フェードイン、アウトのクラス </summary>
    Fade _fade;
    /// <summary> 現在の攻撃状態 </summary>
    string _attackType = "音波";
    /// <summary> クリア判定をリザルトシーンに伝えるbool </summary>
    static bool _isClear = false;

    /// <summary> 敵をまとめた親オブジェクト </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> スポナーをまとめた親オブジェクト </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    /// <summary> 敵をまとめるList </summary>
    public List<GameObject> SceneEnemies { get => _sceneEnemies; set => _sceneEnemies = value; }
    /// <summary> スポナーをまとめるList </summary>
    public List<GameObject> Spawner { get => _spawner; set => _spawner = value; }
    public string AttackType { get => _attackType; set => _attackType = value; }
    /// <summary> クリア判定をリザルトシーンに伝えるbool </summary>
    public static bool IsClear { get => _isClear; set => _isClear = value; }
    /// <summary> クリアウェーブ数 </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _fade = GetComponent<Fade>();
        IsClear = false;
        _player.RangeLV = 0;

        //各Listにシーン上の該当要素を追加する(最初に既に敵が存在している場合)
        //↓敵
        if (EnemyParent.transform.childCount > 0)
        {
            foreach (Transform child in EnemyParent.GetComponentInChildren<Transform>())
            {
                SceneEnemies.Add(child.gameObject);
            }
        }
        //↓スポナー
        if (SpawnerParent.transform.childCount > 0)
        {
            foreach (Transform child in SpawnerParent.GetComponentInChildren<Transform>())
            {
                if (child.gameObject.CompareTag(_spawnerTag))
                {
                    Spawner.Add(child.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _attackTypeText.text = _attackType;

        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            _player.RangeLV++;
            Debug.Log(WaveCount);
            //全てのWaveをクリアしたら、リザルト画面へ遷移
            if (WaveCount == 5)
            {
                IsClear = true;
                _fade.FadeStart();
            }
        }
    }

    /// <summary> GameOver時の処理(シーン遷移等) </summary>
    public void GameOver()
    {
        IsClear = false;
        _fade.FadeStart();
    }
}
