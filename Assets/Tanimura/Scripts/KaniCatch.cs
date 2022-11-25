using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniCatch : MonoBehaviour
{
    [Tooltip("�J�j�̃^�O")]
    [SerializeField, TagName] string _crabTag;
    [Tooltip("�J�j�̃C���X�g�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _crabIllust;
    GameObject _hitCrabObj;
    PlayerShot _playerShot;
    /// <summary>�J�j���L���b�`�\���ǂ������肷��</summary>
    bool _isCanKaniCatch = false;
    /// <summary>�J�j���L���b�`�\���ǂ������肷��v���p�e�B</summary>
    public bool IsCanKaniCatch { get => _isCanKaniCatch; set => _isCanKaniCatch = value; }


    void Start()
    {
        _playerShot = gameObject.transform.parent.gameObject.GetComponent<PlayerShot>();
    }


    void Update()
    {
        //�J�j���L���b�`�\���A�J�j�������Ă��Ȃ��Ƃ��ɃJ�j���L���b�`����
        if(Input.GetKeyDown(KeyCode.LeftShift) && _playerShot.IsKaniCatch == false)
        {
            if(IsCanKaniCatch)
            {
                //��ԋ߂��J�j�������Ď����̃J�j�̃C���X�g��\��������
                Destroy(_hitCrabObj);
                gameObject.SetActive(false);
                _crabIllust.SetActive(true);
                _playerShot.IsKaniCatch = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _crabTag)
        {
            IsCanKaniCatch = true;
            _hitCrabObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(IsCanKaniCatch)
        {
            IsCanKaniCatch = false;
        }
    }

    /// <summary>�J�j�𓊂������ɕ\��������</summary>
    public void KaniLost(GameObject check)
    {
        Debug.Log("a");
        _crabIllust.SetActive(false);
        _crabIllust = check;
    }
}
