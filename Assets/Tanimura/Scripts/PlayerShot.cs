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
    [SerializeField] GameObject _gameManager;
    
   
    bool _isKaniCatch;

    int _rangeLV = 0;
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }
    /// <summary>�Q�[���}�l�[�W���[����U���̔�����󂯎�邽�߂̕ϐ� </summary>
    GameManager _attackTypeJudge;
    VitalCapacity _healJudge;
    KaniCatch _kaniCatchJudge;
    

    void Start()
    {
        //���ƂŃQ�[���}�l�[�W���[���牽�̍U�����o�����󂯎��
        _attackTypeJudge = _gameManager.GetComponent<GameManager>();
        _healJudge = gameObject.GetComponent<VitalCapacity>();
        _kaniCatchJudge = gameObject.GetComponent<KaniCatch>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_isKaniCatch)
            {
                //�����鏈��������
                _crabBullet.SetActive(false);

            }
            else if (_attackTypeJudge.Type == GameManager.AttackType.Normal)
            {
                //�U�����΂�����������(�Ƃ肠�������g���΂����������B���[�e�[�V�����̒l�ō��E�𔻒肵�Ăǂ����ɔ�΂������߂Ă���)
                Debug.Log("LeftClick");
                //���g�̔�΂������A���if���Ő؂�ւ����悤�ɂ���
                GameObject shot = Instantiate(_soundWave[_rangeLV]);
                shot.transform.position = this.gameObject.transform.position;
                if (this.gameObject.transform.localEulerAngles.y == 180)
                {
                    shot.GetComponent<SoundWave>().Dir = -1;
                    Debug.Log(shot.GetComponent<SoundWave>().Dir);
                }
            }

            //�x���ʂ�����Ă���Ȃ�U�����o��
            if (_healJudge.VitalCapacityUse(_temperatureWaveCost))
            {
                //if(Flame)
                //�����̈ʒu����}�E�X�̈ʒu�Ɍ������ĉ��x�g���o��
                GameObject shot = Instantiate(_flameWave[_rangeLV], gameObject.transform.position, Quaternion.identity);

                //if(Snow)
                //{
                //GameObject shot = Instantiate(_snowWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
                //}
                var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
                var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
                shot.transform.localRotation = rotation;
                StartCoroutine(IsRecovery(0.5f));

            }


        }
        //�U���؂�ւ��̓��͎�t
        if (Input.GetButtonDown("Fire2"))
        {
            //�U���؂�ւ��̏�������ŏ���
            Debug.Log("RightClick");
            _attackTypeJudge.AttackSwitch();
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_isKaniCatch ==false)
            {
                if(_kaniCatchJudge.IsKaniCatch())
                {
                    _crabBullet.SetActive(true);
                }
            }
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
}
