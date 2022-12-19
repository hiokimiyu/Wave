using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�I�u�W�F�N�g���j�󂳂�鎞�A�V�[����������AList������폜����
    //��List.Count�̃Y����h��
    [Header("�G�̃I�u�W�F�N�g")]
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private GameObject _spawnerParent;
    [SerializeField] private List<GameObject> _sceneEnemies = new();
    [SerializeField] private List<GameObject> _spawner = new();
    [Tooltip("�U���̃��x��")]
    [SerializeField] private AttackTypes _attackRange;

    /// <summary> �N���A�E�F�[�u�� </summary>
    private int _waveCount = 0;
    /// <summary> �X�|�i�[�̃^�O </summary>
    private readonly string _spawnerTag = "Spawner";
    /// <summary> �N���A��������U���g�V�[���ɓ`����bool </summary>
    private static bool _isClear = false;
    /// <summary> �t�F�[�h�C���A�A�E�g�̃N���X </summary>
    private Fade _fade;

    /// <summary> �G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> �N���A��������U���g�V�[���ɓ`����bool </summary>
    public static bool IsClear { get => _isClear; set => _isClear = value; }

    // Start is called before the first frame update
    void Start()
    {
        _fade = GetComponent<Fade>();
        _isClear = false;
        _attackRange.RangeLV = 0;

        //�eList�ɃV�[����̊Y���v�f��ǉ�����(�ŏ��Ɋ��ɓG�����݂��Ă���ꍇ)
        //���G
        if (_enemyParent.transform.childCount > 0)
        {
            foreach (Transform child in _enemyParent.GetComponentInChildren<Transform>())
            {
                _sceneEnemies.Add(child.gameObject);
            }
        }
        //���X�|�i�[
        if (_spawnerParent.transform.childCount > 0)
        {
            foreach (Transform child in _spawnerParent.GetComponentInChildren<Transform>())
            {
                if (child.gameObject.CompareTag(_spawnerTag))
                {
                    _spawner.Add(child.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
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
