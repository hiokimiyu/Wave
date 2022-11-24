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
    [Tooltip("�U���֌W�̉�")]
    [SerializeField] AudioClip[] _attackAudios = new AudioClip[10];
    [Tooltip("���݂̍U���̏�Ԃ�\������UI")]
    [SerializeField] Text _attackTypeText;

    /// <summary> �U���̋��� </summary>
    AttackStrength _strength = AttackStrength.Normal;
    /// <summary> �U���̎�� </summary>
    AttackType _type = AttackType.Cold;
    /// <summary> �����Đ�����Manager </summary>
    SoundManager _sound;
    /// <summary> �t�F�[�h�C���A�A�E�g�̃N���X </summary>
    Fade _fade;
    /// <summary> ���݂̍U����� </summary>
    string _attackType = "���g";

    /// <summary> �G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> �X�|�i�[���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    /// <summary> �U���̋��� </summary>
    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }
    /// <summary> �G���܂Ƃ߂�List </summary>
    public List<GameObject> SceneEnemies { get; set; }
    /// <summary> �X�|�i�[���܂Ƃ߂�List </summary>
    public List<GameObject> Spawner { get; set; }
    /// <summary> �N���A�E�F�[�u�� </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<SoundManager>();
        _fade = GetComponent<Fade>();

        //�eList�ɃV�[����̊Y���v�f��ǉ�����(�ŏ��Ɋ��ɓG�����݂��Ă���ꍇ)
        //���G
        if (EnemyParent.transform.childCount > 0)
        {
            foreach (Transform child in EnemyParent.transform)
            {
                SceneEnemies.Add(child.gameObject);
            }
        }
        //���X�|�i�[
        if (SpawnerParent.transform.childCount > 0)
        {
            foreach (Transform child in SpawnerParent.transform)
            {
                Spawner.Add(child.gameObject);
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
            Debug.Log(WaveCount);
            //�S�Ă�Wave���N���A������A���U���g��ʂ֑J��
            if (WaveCount == 5)
            {
                _fade.FadeStart();
            }
        }
    }

    /// <summary>
    /// Player�̍U��
    /// PlayerShot -> Update -> if(.....("Fire1")) �̕����ɂ�����x�����Ă��邽��
    /// +���ł�肻���Ȃ��Ƃ������Ă���
    /// �g��Ȃ�����?
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
        if (Strength == AttackStrength.Normal)
        {
            Strength = AttackStrength.Middle;
            _attackType = "������Ƌ���";
        }
        else if (Strength == AttackStrength.Middle)
        {
            if (Type == AttackType.Cold)
                Type = AttackType.Warm;
            else
                Type = AttackType.Cold;

            Strength = AttackStrength.PowerAttack;
            _attackType = "�Ռ��g";
        }
        else if (Strength == AttackStrength.PowerAttack)
        {
            Strength = AttackStrength.Normal;
            _attackType = "���g(����)";
        }
    }

    /// <summary> �U���̋��� </summary>
    public enum AttackStrength
    {
        /// <summary> ���g(�ʏ�) </summary>
        Normal,
        /// <summary> ������Ƌ������ </summary>
        Middle,
        /// <summary> �Ռ��g </summary>
        PowerAttack,
    }

    /// <summary> �U���̎�� </summary>
    public enum AttackType
    {
        /// <summary> ���g </summary>
        Cold,
        /// <summary> �M�g </summary>
        Warm,
    }
}
