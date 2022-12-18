using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypes : MonoBehaviour
{
    [SerializeField] private GameObject[] _soundWave;
    [SerializeField] private GameObject[] _flameWave;
    [SerializeField] private GameObject[] _snowWave;
    [SerializeField] private GameObject[] _shockWave;
    [Tooltip("���g�̏���x����")]
    [SerializeField] private int _soundWaveCost;
    [Tooltip("�Ռ��g�̏���x����")]
    [SerializeField] private int _shockWaveCost;
    [Tooltip("���x�g�̏���x����")]
    [SerializeField] private int _temperatureWaveCost;
    [Tooltip("�J�j�̒e�̎q�I�u�W�F�N�g")]
    [SerializeField] private GameObject _crabBullet;
    [Tooltip("�J�j��ǂ��Ă��邩�ǂ����̔���")]
    [SerializeField] private bool _isKaniCatch = false;

    /// <summary>�˒������̃��x��</summary>
    private int _rangeLV = 0;
    /// <summary> ���I�u�W�F�N�g(�J�j�̃C���X�g) </summary>
    private GameObject _grandChild;
    private GameObject _player;
    private GameObject _muzzle;

    private KaniCatch _kaniCatchJudge;
    private VitalCapacity _healJudge;
    private AttackStatus _attackStatus;

    /// <summary>�˒������̃��x���̃v���p�e�B</summary>
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }

    void Start()
    {
        _player = GameObject.Find("TestPlayer");

        _muzzle = _player.transform.GetChild(0).gameObject;
        _grandChild = _muzzle.GetComponent<Transform>().transform.GetChild(0).gameObject;

        _kaniCatchJudge = _muzzle.GetComponent<KaniCatch>();
        _healJudge = _player.GetComponent<VitalCapacity>();
        _attackStatus = GameObject.Find("Switch").GetComponent<AttackStatus>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //�J�j�������Ă����炻�̂܂ܔ�΂�
            if (_kaniCatchJudge.CrabIllust.activeSelf)
            {
                Debug.Log("Throw crab away");
                //�����鏈��
                Instantiate(_crabBullet, _muzzle.transform.position, Quaternion.identity);
                //�J�j�𓊂�����Ɏ茳�̃J�j�̕\��������
                _grandChild.SetActive(false);
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
            Instantiate(_soundWave[_rangeLV], _player.transform.position, Quaternion.identity);
            StartCoroutine(IsRecovery(1f));
        }
    }

    private void MiddleAttack()
    {
        //�x���ʂ�����Ă��邩�̔���
        if (_healJudge.VitalCapacityUse(_temperatureWaveCost))
        {
            GameObject shot;

            if (_attackStatus.Type == AttackStatus.AttackType.Warm)
            {
                //�����̈ʒu����}�E�X�̈ʒu�Ɍ������ĔM�g���o��
                shot = Instantiate(_flameWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                //�����̈ʒu����}�E�X�̈ʒu�Ɍ������Ċ��g���o��
                shot = Instantiate(_snowWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
            }

            var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
            var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
            shot.transform.localRotation = rotation;
            StartCoroutine(IsRecovery(1f));
        }
    }

    private void PowerAttack()
    {
        if (_healJudge.VitalCapacityUse(_shockWaveCost))
        {
            Instantiate(_shockWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
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
