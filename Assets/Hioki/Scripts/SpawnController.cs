using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Tooltip("�o�������G")]
    [SerializeField]List<GameObject> _enemy = new List<GameObject>();
    [Tooltip("���ɂ��o���ʒu")]
    [SerializeField]Transform _spawnKaniPos;
    [Tooltip("�e���T�g���o���ʒu")]
    [SerializeField]Transform _spawnTeresaPos;
    [Tooltip("�G���o���Ԋu")]
    [SerializeField] float _time = 3f;
    float _enemytime;

    void Update()
    {
        _enemytime += Time.deltaTime;
        //�o���G�������_���Ō��߂�
        int type = Random.Range(0, _enemy.Count);
        //�G�̌����������_���Ō��߂�
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
