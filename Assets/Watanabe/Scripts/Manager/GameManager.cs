using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�I�u�W�F�N�g���j�󂳂�鎞�A�V�[����������AList������폜����
    //��List.Count�̃Y����h��
    [Header("�G�̃I�u�W�F�N�g")]
    [SerializeField] private GameObject _enemyParent = default;
    [SerializeField] private GameObject _spawnerParent = default;
    [SerializeField] private List<GameObject> _sceneEnemies = new();
    [SerializeField] private List<GameObject> _spawner = new();

    /// <summary> �N���A�E�F�[�u�� </summary>
    private int _waveCount = 0;
    /// <summary> �N���A��������U���g�V�[���ɓ`����bool </summary>
    private static bool _isClear = false;
    /// <summary> �U���̃��x�� </summary>
    private AttackTypes _attackRange = default;
    /// <summary> �t�F�[�h�C���A�A�E�g </summary>
    private Fade _fade = default;

    /// <summary> �G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent => _enemyParent;
    /// <summary> �N���A��������U���g�V�[���ɓ`����bool </summary>
    public static bool IsClear => _isClear;

    private void Start()
    {
        _attackRange = GetComponent<AttackTypes>();
        _fade = GetComponent<Fade>();
        _attackRange.RangeLV = 0;
    }

    private void Update()
    {
        if (_sceneEnemies.Count == 0 && _spawner.Count == 0)
        {
            _waveCount++;
            _attackRange.RangeLV++;
            //�S�Ă�Wave���N���A������A���U���g��ʂ֑J��
            if (_waveCount == 5)
            {
                _isClear = true;
                _fade.FadeStart();
            }
        }
    }

    /// <summary> GameOver���̏���(�V�[���J�ړ�) </summary>
    public void GameOver()
    {
        _isClear = false;
        _fade.FadeStart();
    }
}
