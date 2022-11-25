using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour, IDamage
{
    [Tooltip("出したい敵")]
    [SerializeField] List<GameObject> _enemy = new List<GameObject>();
    [Tooltip("かにを出す位置")]
    [SerializeField] Transform _spawnKaniPos;
    [Tooltip("テレサ組を出す位置")]
    [SerializeField] Transform _spawnTeresaPos;
    [Tooltip("敵を出す間隔")]
    [SerializeField] float _time = 3f;
    [Tooltip("下からスポーンさせたい敵のタグ")]
    [SerializeField, TagName] string _kaniTag;
    [Tooltip("GameManager")]
    [SerializeField] GameManager _gameManager;
    [Tooltip("SoundManager")]
    [SerializeField] SoundManager _soundManager;
    /// <summary>敵を出す間隔はかるタイマー</summary>
    float _enemytime;
    /// <summary> HP</summary>
    int _hp = 20;

    //テストしやすいように見えるようにしておくもの↓


    void Update()
    {
        _enemytime += Time.deltaTime;

        if (_time < _enemytime)
        {
            //出す敵をランダムで決める
            int type = Random.Range(0, _enemy.Count);
            //敵の向きをランダムで決める
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //ランダムで敵を出して、EnemyBoxの子オブジェクトにする
            Instantiate(_enemy[type], SpwanPos(_enemy[type]).position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
            _enemytime = 0;
        }//敵を出す時間になったら
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }//HPがなくなったら
    }

    Transform SpwanPos(GameObject go)
    {
        if (go.tag == _kaniTag)
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
        _soundManager.AudioPlay();
    }

    //public override int Activate()
    //{
    //    int a = Random.Range(0, EnemyList.Count);
    //    return a;
    //}

}