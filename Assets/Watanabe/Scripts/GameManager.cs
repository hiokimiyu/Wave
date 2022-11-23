using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("�G���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("�X�|�i�[���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _spawnerParent;
    [Tooltip("�U���֌W�̉�")]
    [SerializeField] AudioClip[] _attackAudios = new AudioClip[10];
    [Tooltip("���݂̍U���̏�Ԃ�\������UI")]
    [SerializeField] Text _attackTypeText;

    /// <summary> �U���̎�� </summary>
    AttackType _type = AttackType.Normal;
    /// <summary> �����Đ�����Manager </summary>
    SoundManager _sound;
    string _attackType = "���g";

    /// <summary> �V�[����̓G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> �V�[����̃X�|�i�[���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    public AttackType Type { get => _type; set => _type = value; }
    /// <summary> �V�[����ɂ���G </summary>
    public List<GameObject> SceneEnemies { get; set; }
    /// <summary> �V�[����̃X�|�i�[ </summary>
    public List<GameObject> Spawner { get; set; }
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
        _attackTypeText.text = _attackType;

        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
        }
    }

    /// <summary>
    /// Player�̍U��
    /// PlayerShot -> Update -> if(.....("Fire1")) �̕����ɂ�����x�����Ă��邽�߁A
    /// +���ł�肻���Ȃ��Ƃ������Ă���
    /// </summary>
    void PlayerAttack()
    {
        //SE�Đ�(���݂͓K���ɐݒ肵�Ă��邽�߁A��Œ���)
        _sound.AudioPlay(_attackAudios[0]);
    }

    /// <summary>
    /// �U���̐؂�ւ�
    /// PlayerShot -> Update -> if(.....("Fire2")) �̕����ŌĂяo��
    /// UI�̕\��(���݂̏�Ԃ��������邽��)
    /// </summary>
    public void AttackSwitch()
    {
        //���݂̏�Ԃɂ���Đ؂�ւ���(���Ԃ�)
        //UI�\���̏���������
        if (Type == AttackType.Normal)
        {
            Type = AttackType.Warm;
            _attackType = "�M�g";
        }
        else if (Type == AttackType.Warm)
        {
            Type = AttackType.Cold;
            _attackType = "���g";
        }
        else if (Type == AttackType.Cold)
        {
            Type = AttackType.PowerAttack;
            _attackType = "�Ռ��g";
        }
        else if (Type == AttackType.PowerAttack)
        {
            Type = AttackType.Normal;
            _attackType = "���g";
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
        /// <summary> �Ռ��g </summary>
        PowerAttack,
    }
}
