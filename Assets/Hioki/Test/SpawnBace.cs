using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBace : MonoBehaviour
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
    /// <summary>�G���o���Ԋu�͂���^�C�}�[</summary>
    float _enemytime;

    void Update()
    {
        _enemytime += Time.deltaTime;
            
    }

    void SpawnSystem(int n)
    {
        if (_time < _enemytime)
        {
            //�G�̌����������_���Ō��߂�
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //�����_���œG���o���āAEnemyBox�̎q�I�u�W�F�N�g�ɂ���
            Instantiate(_enemy[n], SpwanPos(_enemy[n]).position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
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
