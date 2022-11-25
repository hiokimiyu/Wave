using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [Tooltip("���g�̃v���n�u")]
    [SerializeField] GameObject[] _soundWave;
    [Tooltip("���g�̏���x����")]
    [SerializeField] int _soundWaveCost;
    [Tooltip("�M�g�̃v���n�u")]
    [SerializeField] GameObject[] _flameWave;
    [Tooltip("���g�̃v���n�u")]
    [SerializeField] GameObject[] _snowWave;
    [Tooltip("���x�g�̏���x����")]
    [SerializeField] int _temperatureWaveCost;
    [Tooltip("�Ռ��g�̃v���n�u")]
    [SerializeField] GameObject[] _shockWave;
    [Tooltip("�Ռ��g�̏���x����")]
    [SerializeField] int _shockWaveCost;
    [Tooltip("�J�j�̒e�̎q�I�u�W�F�N�g")]
    [SerializeField] GameObject _crabBullet;
    [Tooltip("�U���̔�����󂯎�邽�߂̕ϐ�")]
    [SerializeField] GameObject _gameManager;
    
   /// <summary>�J�j��ǂ��Ă��邩�ǂ����̔���</summary>
    bool _isKaniCatch;
    /// <summary>�J�j��ǂ��Ă��邩�ǂ����̔���̃v���p�e�B</summary>
    public bool IsKaniCatch { get => _isKaniCatch; set => _isKaniCatch = value; }
    /// <summary>�˒������̃��x��</summary>
    int _rangeLV = 0;
    /// <summary>�˒������̃��x���̃v���p�e�B</summary>
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }
    /// <summary>�x���ʂ̔���̃X�N���v�g</summary>
    VitalCapacity _healJudge;
    /// <summary>�J�j�̐ڐG����̃X�N���v�g</summary>
    KaniCatch _kaniCatchJudge;
    /// <summary>�U����ނ̔���̃X�N���v�g</summary>
    GameManager _attackJudge;
    

    void Start()
    {
        _attackJudge = _gameManager.GetComponent<GameManager>();
        _healJudge = gameObject.GetComponent<VitalCapacity>();
        _kaniCatchJudge = gameObject.transform.GetChild(0).GetComponent<KaniCatch>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //�J�j�������Ă����炻�̂܂ܔ�΂�
            if (_isKaniCatch)
            {
                //�����鏈��
                KaniShot();
                IsKaniCatch = false;
                //�J�j�𓊂�����ɃJ�j�̕\��������
                _kaniCatchJudge.KaniLost(transform.GetChild(0).gameObject);
                _crabBullet.GetComponent<SpriteRenderer>().enabled = false;
                //_crabBullet.SetActive(false);

            }
            //�U����ނ̔���,���g
            else if (_attackJudge.Strength == GameManager.AttackStrength.Normal)
            {
                //�x���ʂ�����Ă��邩�̔���
                if (_healJudge.VitalCapacityUse(_soundWaveCost))
                {
                    //�U�����΂�����������(�Ƃ肠�������g���΂����������B���[�e�[�V�����̒l�ō��E�𔻒肵�Ăǂ����ɔ�΂������߂Ă���)
                    Debug.Log("LeftClick");
                    //���g�̔�΂�����
                    GameObject shot = Instantiate(_soundWave[_rangeLV]);
                    shot.transform.position = this.gameObject.transform.position;
                    StartCoroutine(IsRecovery(0.5f));
                    if (this.gameObject.transform.localEulerAngles.y == 180)
                    {
                        shot.GetComponent<SoundWave>().Dir = -1;
                        Debug.Log(shot.GetComponent<SoundWave>().Dir);
                    }
                }
            }
            //�U����ނ̔���,���x�g
            else if(_attackJudge.Strength == GameManager.AttackStrength.Middle)
            {
                //�x���ʂ�����Ă��邩�̔���
                if (_healJudge.VitalCapacityUse(_temperatureWaveCost))
                {
                    GameObject shot;
                    if (_attackJudge.Type == GameManager.AttackType.Warm)
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
            //�U����ނ̔���,�Ռ��g
            else if(_attackJudge.Strength == GameManager.AttackStrength.PowerAttack)
            {
                if(_healJudge.VitalCapacityUse(_shockWaveCost))
                {
                    GameObject shot = Instantiate(_shockWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
                    StartCoroutine(IsRecovery(0.5f));
                }
            }


        }
        //�U���؂�ւ��̓��͎�t
        if (Input.GetButtonDown("Fire2"))
        {
            //�U���؂�ւ��̏�������ŏ���
            Debug.Log("RightClick");
            _attackJudge.AttackSwitch();
        }
    }

    /// <summary> �U���㏭�������x���ʂ̉񕜂��~�߂āA�܂��ĊJ���鏈�� </summary>
    /// <param name="RearGap"></param>
    /// <returns></returns>
    IEnumerator IsRecovery(float RearGap)
    {
        _healJudge.IsRecovery = false;
        yield return new WaitForSeconds(RearGap);
        _healJudge.IsRecovery = true;
        Debug.Log(_healJudge.IsRecovery);
    }

    /// <summary>�J�j���΂��āA�����Ă��Ȃ����Ƃɂ���</summary>
    public void KaniShot()
    {
        KaniBullet.Instantiate(_crabBullet, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        
    }
}
