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
    [SerializeField] GameObject _gameManager;
    /// <summary>�Q�[���}�l�[�W���[����U���̔�����󂯎�邽�߂̕ϐ� </summary>
    GameManager _attackTypeJudge;


    void Start()
    {
        //���ƂŃQ�[���}�l�[�W���[���牽�̍U�����o�����󂯎��
        //_attackTypeJudge = _gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //�U�����΂�����������(�Ƃ肠�������g���΂����������B���[�e�[�V�����̒l�ō��E�𔻒肵�Ăǂ����ɔ�΂������߂Ă���)
            Debug.Log("LeftClick");
            //���g�̔�΂������A���if���Ő؂�ւ����悤�ɂ���
            //GameObject shot =  Instantiate(_soundWave);
            //shot.transform.position = this.gameObject.transform.position;
            //if (this.gameObject.transform.localEulerAngles.y == 180)
            //{
            //    shot.GetComponent<SoundWave>().Dir = -1;
            //    Debug.Log(shot.GetComponent<SoundWave>()._dir);
            //}

            //�����̈ʒu����}�E�X�̈ʒu�Ɍ������ĉ��x�g���o��
            GameObject shot = Instantiate(_flameWave[0],gameObject.transform.position,Quaternion.identity);
            var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
            var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
            shot.transform.localRotation = rotation;


        }
        //�U���؂�ւ��̓��͎�t
        if (Input.GetButtonDown("Fire2"))
        {
            //�U���؂�ւ��̏�������ŏ���
            Debug.Log("RightClick");
        }
    }
}
