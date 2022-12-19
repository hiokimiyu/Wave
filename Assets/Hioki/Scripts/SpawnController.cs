using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour, IDamage
{
    [Tooltip("スポーンさせる敵の種類")]
    [SerializeField] private List<GameObject> _enemy = new();
    [Tooltip("かにを出す位置")]
    [SerializeField] private Transform _spawnKaniPos;
    [Tooltip("テレサ組を出す位置")]
    [SerializeField] private Transform _spawnTeresaPos;
    [Tooltip("敵を出す間隔")]
    [SerializeField] private float _time = 3f;

    /// <summary>敵を出す間隔はかるタイマー</summary>
    private float _enemytime = 0f;
    private int _hp = 20;
    private readonly string _kaniTag = "Crab";
    private GameObject _managers;
    private GameManager _gameManager;
    private SoundManager _soundManager;

    private void Start()
    {
        _managers = GameObject.Find("Managers");
        _gameManager = _managers.GetComponent<GameManager>();
        _soundManager = _managers.GetComponent<SoundManager>();
    }

    void Update()
    {
        _enemytime += Time.deltaTime;

        if (_time < _enemytime)
        {
            //出す敵をランダムで決める
            int type = Random.Range(0, _enemy.Count);
            //敵の向きをランダムで決める
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //ランダムで敵を出して、EnemyParentの子オブジェクトにする
            Instantiate(_enemy[type], SpwanPos(_enemy[type]).position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
            _enemytime = 0;
        }//敵を出す時間になったら

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }//HPがなくなったら
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

    void IDamage.Damage()
    {
        _hp--;
        _soundManager.AudioPlay(_soundManager.AttackAudios[2]);
    }
}