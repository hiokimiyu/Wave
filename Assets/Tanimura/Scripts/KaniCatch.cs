using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniCatch : MonoBehaviour
{
    private readonly string _crabTag = "Crab";
    /// <summary> �J�j�̃C���X�g�̃I�u�W�F�N�g </summary>
    private GameObject _crabIllust;
    /// <summary> ���ނ��Ƃ��o����J�j </summary>
    private GameObject _hitCrabObj;

    public GameObject CrabIllust { get => _crabIllust; set => _crabIllust = value; }

    private void Awake()
    {
        _crabIllust = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        _crabIllust.SetActive(false);
    }

    private void Update()
    {
        //�J�j���L���b�`�\���A�J�j�������Ă��Ȃ��Ƃ��ɃJ�j���L���b�`����
        if(Input.GetKeyDown(KeyCode.LeftShift) && _hitCrabObj != null)
        {
            //��ԋ߂��J�j�������Ď����̃J�j�̃C���X�g��\��������
            Destroy(_hitCrabObj);
            _crabIllust.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(_crabTag) && _hitCrabObj == null)
        {
            _hitCrabObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_hitCrabObj != null)
        {
            _hitCrabObj = null;
        }
    }
}
