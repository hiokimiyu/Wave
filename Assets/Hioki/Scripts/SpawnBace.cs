using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBace : MonoBehaviour
{
    [Tooltip("出したい敵のList")]
    [SerializeField] private List<GameObject> _enemy = new();
    [Tooltip("かにを出す位置")]
    [SerializeField] private Transform _spawnKaniPos;
    [Tooltip("テレサ組を出す位置")]
    [SerializeField] private Transform _spawnTeresaPos;
    [Tooltip("敵を出す間隔")]
    [SerializeField] private float _time = 3f;

    /// <summary> 下からスポーンさせたい敵のタグ </summary>
    private readonly string _kaniTag = "Crab";
    /// <summary>敵を出す間隔はかるタイマー</summary>
    private float _enemytime = 0f;
    private GameManager _gameManager;

    public List<GameObject> EnemyList { get => _enemy; set => _enemy = value; }

    /// <summary>
    /// インデックス指定
    /// </summary>
    public abstract int Activate();

    private void Start()
    {
        _gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
    }

    private void Update()
    {
        //一定時間経ったら敵を出現させる
        _enemytime += Time.deltaTime;
        if (_time < _enemytime)
        {
            //敵の向きをランダムで決める
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //ランダムで敵を出して、EnemyBoxの子オブジェクトにする
            Instantiate(_enemy[Activate()], SpwanPos(_enemy[Activate()]).position,
                Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
            _enemytime = 0;
        }
    }

    private Transform SpwanPos(GameObject go)
    {
        if (go.CompareTag(_kaniTag))
        {
            return _spawnKaniPos;
        }//かにのタグだったら下のスポーン位置を返す
        else
        {
            return _spawnTeresaPos;
        }//かに以外だったら上のスポーン位置を返す
    }
}
