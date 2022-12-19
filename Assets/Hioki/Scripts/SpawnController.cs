using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour, IDamage
{
    [Tooltip("�X�|�[��������G�̎��")]
    [SerializeField] private List<GameObject> _enemy = new();
    [Tooltip("���ɂ��o���ʒu")]
    [SerializeField] private Transform _spawnKaniPos;
    [Tooltip("�e���T�g���o���ʒu")]
    [SerializeField] private Transform _spawnTeresaPos;
    [Tooltip("�G���o���Ԋu")]
    [SerializeField] private float _time = 3f;

    /// <summary>�G���o���Ԋu�͂���^�C�}�[</summary>
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
            //�o���G�������_���Ō��߂�
            int type = Random.Range(0, _enemy.Count);
            //�G�̌����������_���Ō��߂�
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //�����_���œG���o���āAEnemyParent�̎q�I�u�W�F�N�g�ɂ���
            Instantiate(_enemy[type], SpwanPos(_enemy[type]).position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
            _enemytime = 0;
        }//�G���o�����ԂɂȂ�����

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }//HP���Ȃ��Ȃ�����
    }

    private Transform SpwanPos(GameObject go)
    {
        if (go.CompareTag(_kaniTag))
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
        _soundManager.AudioPlay(_soundManager.AttackAudios[2]);
    }
}