using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBace : MonoBehaviour
{
    [Tooltip("�o�������G��List")]
    [SerializeField] private List<GameObject> _enemy = new();
    [Tooltip("���ɂ��o���ʒu")]
    [SerializeField] private Transform _spawnKaniPos;
    [Tooltip("�e���T�g���o���ʒu")]
    [SerializeField] private Transform _spawnTeresaPos;
    [Tooltip("�G���o���Ԋu")]
    [SerializeField] private float _time = 3f;

    /// <summary> ������X�|�[�����������G�̃^�O </summary>
    private readonly string _kaniTag = "Crab";
    /// <summary>�G���o���Ԋu�͂���^�C�}�[</summary>
    private float _enemytime = 0f;
    private GameManager _gameManager;

    public List<GameObject> EnemyList { get => _enemy; set => _enemy = value; }

    /// <summary>
    /// �C���f�b�N�X�w��
    /// </summary>
    public abstract int Activate();

    private void Start()
    {
        _gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
    }

    private void Update()
    {
        //��莞�Ԍo������G���o��������
        _enemytime += Time.deltaTime;
        if (_time < _enemytime)
        {
            //�G�̌����������_���Ō��߂�
            int y = Random.Range(0, 2) == 0 ? 0 : 180;
            //�����_���œG���o���āAEnemyBox�̎q�I�u�W�F�N�g�ɂ���
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
        }//���ɂ̃^�O�������牺�̃X�|�[���ʒu��Ԃ�
        else
        {
            return _spawnTeresaPos;
        }//���ɈȊO���������̃X�|�[���ʒu��Ԃ�
    }
}
