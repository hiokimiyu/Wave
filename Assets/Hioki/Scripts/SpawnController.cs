using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Tooltip("�o�������G")]
    [SerializeField] List<GameObject> _enemy = new List<GameObject>();
    [Tooltip("���ɂ��o���ʒu")]
    [SerializeField] Transform _spawnKaniPos;
    [Tooltip("�e���T�g���o���ʒu")]
    [SerializeField] Transform _spawnTeresaPos;
    [Tooltip("�G���o���Ԋu")]
    [SerializeField] float _time = 3f;
    [Tooltip("������X�|�[�����������G�̃^�O")]
    [SerializeField, TagName] string _kaniTag;
    [Tooltip("�G�l�~�[���i�[����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _enemyBox;
    /// <summary>�G���o���Ԋu�͂���^�C�}�[</summary>
    float _enemytime;

    //�e�X�g���₷���悤�Ɍ�����悤�ɂ��Ă������́�
    

    void Update()
    {
        _enemytime += Time.deltaTime;
        //�o���G�������_���Ō��߂�
        int type = Random.Range(0, _enemy.Count);
        //�G�̌����������_���Ō��߂�
        int y = Random.Range(0, 2) == 0 ? 0 : 180;
        if (_time < _enemytime)
        {
            //�����_���œG���o���āAEnemyBox�̎q�I�u�W�F�N�g�ɂ���
            Instantiate(_enemy[type], SpwanPos(_enemy[type]).position, Quaternion.Euler(0, y, 0), _enemyBox.transform);
            _enemytime = 0;
        }
    }

    Transform SpwanPos(GameObject go)
    {
        if (go.tag == _kaniTag)
        {
            return _spawnKaniPos;
        }//���ɂ̃^�O�������牺�̃X�|�[���ʒu��Ԃ�
        else
        {
            return _spawnTeresaPos;
        }//���ɈȊO���������̃X�|�[���ʒu��Ԃ�
    }
}
