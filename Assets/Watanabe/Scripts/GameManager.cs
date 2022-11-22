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
    [Tooltip("�U���֌W�̉�")]
    [SerializeField] AudioClip[] _attackAudio = new AudioClip[10];

    /// <summary> �V�[�����s���̎��� </summary>
    float _time = 0f;
    /// <summary> �U���̎�� </summary>
    AttackType _type = AttackType.Normal;
    /// <summary> �����Đ�����Manager </summary>
    SoundManager _sound;

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
        _sound = GetComponent<SoundManager>();

        //�eList�ɃV�[����̊Y���v�f��ǉ�����(�ŏ��Ɋ��ɓG�����݂��Ă���ꍇ)
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
            Debug.Log(IsWarm);
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
    /// PlayerShot -> Update -> if(.....("Fire1")) �̕����ŌĂяo��
    /// </summary>
    public void PlayerAttack()
    {
        //Animation�Đ�?
        //SE�Đ�(���݂͓K���ɐݒ肵�Ă��邽�߁A��Œ���)
        _sound.AudioPlay(_attackAudio[0]);
    }

    /// <summary>
    /// �U���̐؂�ւ�
    /// PlayerShot -> Update -> if(.....("Fire2")) �̕����ŌĂяo��
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

    /// <summary> �U���̎�� </summary>
    public enum AttackType
    {
        /// <summary> ���g(�ʏ�) </summary>
        Normal,
        /// <summary> ���g </summary>
        Cold,
        /// <summary> �M�g </summary>
        Warm,
    }
}
