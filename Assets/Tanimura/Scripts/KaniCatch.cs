using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniCatch : MonoBehaviour
{
    [Tooltip("カニのタグ")]
    [SerializeField, TagName] string _crabTag;
    [Tooltip("カニのイラストのオブジェクト")]
    [SerializeField] GameObject _crabIllust;
    GameObject _hitCrabObj;
    PlayerShot _playerShot;
    /// <summary>カニがキャッチ可能かどうか判定する</summary>
    bool _isCanKaniCatch;
    /// <summary>カニがキャッチ可能かどうか判定するプロパティ</summary>
    public bool IsCanKaniCatch { get => _isCanKaniCatch; set => _isCanKaniCatch = value; }


    void Start()
    {
        _playerShot = gameObject.transform.parent.gameObject.GetComponent<PlayerShot>();
    }


    void Update()
    {
        //カニがキャッチ可能かつ、カニを持っていないときにカニをキャッチする
        if(Input.GetKeyDown(KeyCode.LeftShift) && _playerShot.IsKaniCatch == false)
        {
            if(IsCanKaniCatch)
            {
                //一番近いカニを消して自分のカニのイラストを表示させる
                Destroy(_hitCrabObj);
                _crabIllust.SetActive(true);
                _playerShot.IsKaniCatch = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _crabTag)
        {
            _isCanKaniCatch = true;
            _hitCrabObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_isCanKaniCatch)
        {
            _isCanKaniCatch = false;
        }
    }

    /// <summary>カニを投げた時に表示を消す</summary>
    public void KaniLost()
    {
        _crabIllust.SetActive(false);
    }
    


}
