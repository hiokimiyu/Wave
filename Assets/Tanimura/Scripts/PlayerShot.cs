using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
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

    /// <summary>�J�j���ˈʒu</summary>
    private GameObject _muzzle;
    /// <summary> ���I�u�W�F�N�g(�J�j�̃C���X�g) </summary>
    private GameObject _grandChild;
    /// <summary>�˒������̃��x��</summary>
    private int _rangeLV = 0;
    private KaniCatch _kaniCatchJudge;
    private VitalCapacity _healJudge;
    private AttackStatus _attackStatus;

    /// <summary>�˒������̃��x���̃v���p�e�B</summary>
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }
    

    void Start()
    {
        _muzzle = transform.GetChild(0).gameObject;
        _grandChild = _muzzle.GetComponent<Transform>().transform.GetChild(0).gameObject;
        _kaniCatchJudge = transform.GetChild(0).GetComponent<KaniCatch>();
        _healJudge = GetComponent<VitalCapacity>();
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
                KaniShot();
                //�J�j�𓊂�����ɃJ�j�̕\��������
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
            GameObject shot = Instantiate(_soundWave[_rangeLV]);
            shot.transform.position = gameObject.transform.position;
            StartCoroutine(IsRecovery(0.5f));

            if (gameObject.transform.localEulerAngles.y == 180)
            {
                shot.GetComponent<SoundWave>().Dir = -1;
            }
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
            StartCoroutine(IsRecovery(0.5f));
        }
    }

    private void PowerAttack()
    {
        if (_healJudge.VitalCapacityUse(_shockWaveCost))
        {
            Instantiate(_shockWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
            StartCoroutine(IsRecovery(0.5f));
        }
    }

    /// <summary>�J�j���΂�</summary>
    private void KaniShot()
    {
        //�J�j���΂�
        Instantiate(_crabBullet, _muzzle.transform.position, Quaternion.identity);
    }

    /// <summary> �U���� RearGap�b �x���ʂ̉񕜂��~�߂āA�܂��ĊJ���鏈�� </summary>
    IEnumerator IsRecovery(float RearGap)
    {
        _healJudge.IsRecovery = false;
        yield return new WaitForSeconds(RearGap);
        _healJudge.IsRecovery = true;
    }
}
