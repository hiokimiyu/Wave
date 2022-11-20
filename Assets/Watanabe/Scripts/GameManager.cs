using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("���g�A�M�g��؂�ւ���^�C�~���O(�b)")]
    [SerializeField, Range(1, 15)] int _switchTime = 0;
    [Tooltip("�J�ڐ�̃V�[����")]
    [SerializeField, SceneName] string _sceneName;
    [Tooltip("�G���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("�X�|�i�[���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _spawnerParent;

    /// <summary> �V�[�����s���̎��� </summary>
    float _time = 0f;
    AttackType _type = AttackType.Normal;

    /// <summary> �V�[����̓G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> �V�[����̃X�|�i�[���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    public AttackType Type { get => _type; set => _type = value; }
    /// <summary> �V�[����ɂ���G </summary>
    public List<GameObject> SceneEnemies { get; set; }
    /// <summary> �V�[����̃X�|�i�[ </summary>
    public List<GameObject> Spawner { get; set; }
    /// <summary> ���g���A�M�g��(false...���g, true...�M�g) </summary>
    public bool IsWarm { get; set; }
    /// <summary> �E�F�[�u�� </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //�eList�ɃV�[����̊Y���v�f��ǉ�����
        //���G
        foreach (Transform child in EnemyParent.transform)
        {
            SceneEnemies.Add(child.gameObject);
        }
        //���X�|�i�[
        foreach (Transform child in SpawnerParent.transform)
        {
            Spawner.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //��莞�Ԍo�߂�����A���g�A�M�g��؂�ւ���
        _time += Time.deltaTime;
        if (_time > _switchTime)
        {
            //���g�A�M�g�̐؂�ւ�(false...���g, true...�M�g)
            IsWarm = IsWarm == true ? false : true;
            _time = 0f;
        }

        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
            //SceneManager.LoadScene(_sceneName);
        }
    }

    /// <summary>
    /// Player�̍U��
    /// </summary>
    public void PlayerAttack()
    {

    }

    /// <summary>
    /// �U���̐؂�ւ�
    /// </summary>
    public void AttackSwitch()
    {
        if (Type == AttackType.Warm)
        {
            Type = AttackType.Cold;
        }
        else if (Type == AttackType.Cold)
        {
            Type = AttackType.Warm;
        }
    }

    public enum AttackType
    {
        Normal,
        Warm,
        Cold
    }
}
