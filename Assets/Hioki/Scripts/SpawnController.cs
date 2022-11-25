using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour, IDamage
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
    [Tooltip("GameManager")]
    [SerializeField] GameManager _gameManager;
    [Tooltip("SoundManager")]
    [SerializeField] SoundManager _soundManager;
    /// <summary>�G���o���Ԋu�͂���^�C�}�[</summary>
    float _enemytime;
    /// <summary> HP</summary>
    int _hp = 20;

    //�e�X�g���₷���悤�Ɍ�����悤�ɂ��Ă������́�


    void Update()
    {
        _enemytime += Time.deltaTime;

        if (_time < _enemytime)
        {
            //�o���G�������_���Ō��߂�
            int type = Random.Range(0, _enemy.Count);
            //�G�̌����������_���Ō��߂�
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //�����_���œG���o���āAEnemyBox�̎q�I�u�W�F�N�g�ɂ���
            Instantiate(_enemy[type], SpwanPos(_enemy[type]).position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
            _enemytime = 0;
        }//�G���o�����ԂɂȂ�����
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }//HP���Ȃ��Ȃ�����
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