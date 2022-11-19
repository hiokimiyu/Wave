using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Tooltip("出したい敵")]
    [SerializeField]List<GameObject> _enemy = new List<GameObject>();
    [Tooltip("かにを出す位置")]
    [SerializeField]Transform _spawnKaniPos;
    [Tooltip("テレサ組を出す位置")]
    [SerializeField]Transform _spawnTeresaPos;
    [Tooltip("敵を出す間隔")]
    [SerializeField] float _time = 3f;
    float _enemytime;

    void Update()
    {
        _enemytime += Time.deltaTime;
        //出す敵をランダムで決める
        int type = Random.Range(0, _enemy.Count);
        //敵の向きをランダムで決める
        int y = Random.Range(0,1) == 0 ? 0 : 180;
        if(_time < _enemytime)
        {
            Instantiate(_enemy[type], SpwanPos(_enemy[type]).position, Quaternion.Euler(0, y, 0));
            _enemytime = 0;
        }
    }

    Transform SpwanPos(GameObject go)
    {
        if(go.name == "Kani")
        {
            return _spawnKaniPos;
        }
        else
        {
            return _spawnTeresaPos;
        }
    }
}
