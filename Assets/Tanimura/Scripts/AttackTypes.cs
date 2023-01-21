using Consts;
using System.Collections;
using UnityEngine;

public class AttackTypes : MonoBehaviour
{
    [SerializeField] private GameObject[] _soundWave = default;
    [SerializeField] private GameObject[] _flameWave = default;
    [SerializeField] private GameObject[] _snowWave = default;
    [SerializeField] private GameObject[] _shockWave = default;
    [Tooltip("���g�̏���x����")]
    [SerializeField] private int _soundWaveCost;
    [Tooltip("�Ռ��g�̏���x����")]
    [SerializeField] private int _shockWaveCost;
    [Tooltip("���x�g�̏���x����")]
    [SerializeField] private int _tempWaveCost;
    [Tooltip("�J�j�̒e�̎q�I�u�W�F�N�g")]
    [SerializeField] private GameObject _crabBullet;
    [Tooltip("�J�j��ǂ��Ă��邩�ǂ����̔���")]
    [SerializeField] private bool _isKaniCatch = false;

    /// <summary>�˒������̃��x��</summary>
    private int _rangeLV = 0;
    private GameObject _player = default;
    private Transform _muzzle = default;

    private KaniCatch _kaniCatchJudge;
    private VitalCapacity _healJudge;
    private AttackStatus _attackStatus;

    /// <summary>�˒������̃��x���̃v���p�e�B</summary>
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);

        _muzzle = _player.transform.GetChild(0).gameObject.GetComponent<Transform>();

        _kaniCatchJudge = _muzzle.GetComponent<KaniCatch>();
        _healJudge = _player.GetComponent<VitalCapacity>();
        _attackStatus = GameObject.Find("Switch").GetComponent<AttackStatus>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //�J�j�������Ă����炻�̂܂ܔ�΂�
            if (_kaniCatchJudge.CrabIllust.activeSelf)
            {
                Debug.Log("Throw crab away");
                //�����鏈��
                Instantiate(_crabBullet, _muzzle.position, Quaternion.identity);
                //�J�j�𓊂�����Ɏ茳�̃J�j�̕\��������
                _muzzle.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Wave attack");
                //�U����ނ̔���,���g
                switch (_attackStatus.Strength)
                {
                    case AttackStatus.AttackStrength.Normal:
                        NormalAttack();
                        break;
                    case AttackStatus.AttackStrength.Middle:
                        MiddleAttack();
                        break;
                    case AttackStatus.AttackStrength.PowerAttack:
                        PowerAttack();
                        break;
                }
            }
        }
        //�U���؂�ւ��̓��͎�t
        if (Input.GetButtonDown("Fire2"))
        {
            _attackStatus.AttackSwitch();
        }
    }

    private void NormalAttack()
    {
        //�x���ʂ�����Ă��邩�̔���
        if (_healJudge.VitalCapacityUse(_soundWaveCost))
        {
            Debug.Log("LeftClick");
            //���g�̔�΂�����
            Instantiate(_soundWave[_rangeLV], _muzzle.position, Quaternion.identity);
            StartCoroutine(IsRecovery(1f));
        }
    }

    private void MiddleAttack()
    {
        //�x���ʂ�����Ă��邩�̔���
        if (_healJudge.VitalCapacityUse(_tempWaveCost))
        {
            if (_attackStatus.Type == AttackStatus.AttackType.Warm)
            {
                //�����̈ʒu����}�E�X�̈ʒu�Ɍ������ĔM�g���o��
                Instantiate(_flameWave[_rangeLV], _muzzle.position, Quaternion.identity);
            }
            else
            {
                //�����̈ʒu����}�E�X�̈ʒu�Ɍ������Ċ��g���o��
                Instantiate(_snowWave[_rangeLV], _muzzle.position, Quaternion.identity);
            }
            StartCoroutine(IsRecovery(1f));
        }
    }

    private void PowerAttack()
    {
        if (_healJudge.VitalCapacityUse(_shockWaveCost))
        {
            Instantiate(_shockWave[_rangeLV], _player.transform.position, Quaternion.identity);
            StartCoroutine(IsRecovery(1f));
        }
    }

    /// <summary> �U���� stopHeal�b �x���ʂ̉񕜂��~�߂āA�܂��ĊJ���鏈�� </summary>
    IEnumerator IsRecovery(float stopHeal)
    {
        _healJudge.IsRecovery = false;
        yield return new WaitForSeconds(stopHeal);
        _healJudge.IsRecovery = true;
    }
}
