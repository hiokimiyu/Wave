using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�I�u�W�F�N�g���j�󂳂�鎞�A�V�[����������AList������폜����
    //��List.Count�̃Y����h��
    [Tooltip("�G���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("�X�|�i�[���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _spawnerParent;
    [Tooltip("�G���܂Ƃ߂�List")]
    [SerializeField] List<GameObject> _sceneEnemies = new();
    [Tooltip("�X�|�i�[���܂Ƃ߂�List")]
    [SerializeField] List<GameObject> _spawner = new();
    [Tooltip("�E�F�[�u�̃��x��")]
    [SerializeField] PlayerShot _player;
    [Tooltip("���݂̍U���̏�Ԃ�\������UI")]
    [SerializeField] Text _attackTypeText;
    [Tooltip("Spawner��Tag")]
    [SerializeField, TagName] string _spawnerTag;

    /// <summary> �t�F�[�h�C���A�A�E�g�̃N���X </summary>
    Fade _fade;
    /// <summary> ���݂̍U����� </summary>
    string _attackType = "���g";
    /// <summary> �N���A��������U���g�V�[���ɓ`����bool </summary>
    static bool _isClear = false;

    /// <summary> �G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> �X�|�i�[���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    /// <summary> �G���܂Ƃ߂�List </summary>
    public List<GameObject> SceneEnemies { get => _sceneEnemies; set => _sceneEnemies = value; }
    /// <summary> �X�|�i�[���܂Ƃ߂�List </summary>
    public List<GameObject> Spawner { get => _spawner; set => _spawner = value; }
    public string AttackType { get => _attackType; set => _attackType = value; }
    /// <summary> �N���A��������U���g�V�[���ɓ`����bool </summary>
    public static bool IsClear { get => _isClear; set => _isClear = value; }
    /// <summary> �N���A�E�F�[�u�� </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _fade = GetComponent<Fade>();
        IsClear = false;
        _player.RangeLV = 0;

        //�eList�ɃV�[����̊Y���v�f��ǉ�����(�ŏ��Ɋ��ɓG�����݂��Ă���ꍇ)
        //���G
        if (EnemyParent.transform.childCount > 0)
        {
            foreach (Transform child in EnemyParent.GetComponentInChildren<Transform>())
            {
                SceneEnemies.Add(child.gameObject);
            }
        }
        //���X�|�i�[
        if (SpawnerParent.transform.childCount > 0)
        {
            foreach (Transform child in SpawnerParent.GetComponentInChildren<Transform>())
            {
                if (child.gameObject.CompareTag(_spawnerTag))
                {
                    Spawner.Add(child.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _attackTypeText.text = _attackType;

        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            _player.RangeLV++;
            Debug.Log(WaveCount);
            //�S�Ă�Wave���N���A������A���U���g��ʂ֑J��
            if (WaveCount == 5)
            {
                IsClear = true;
                _fade.FadeStart();
            }
        }
    }

    /// <summary> GameOver���̏���(�V�[���J�ړ�) </summary>
    public void GameOver()
    {
        IsClear = false;
        _fade.FadeStart();
    }
}
