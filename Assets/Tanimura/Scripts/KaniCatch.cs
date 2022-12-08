using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniCatch : MonoBehaviour
{
    private readonly string _crabTag = "Crab";
    /// <summary> カニのイラストのオブジェクト </summary>
    private GameObject _crabIllust;
    /// <summary> つかむことが出来るカニ </summary>
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
        //カニがキャッチ可能かつ、カニを持っていないときにカニをキャッチする
        if(Input.GetKeyDown(KeyCode.LeftShift) && _hitCrabObj != null)
        {
            //一番近いカニを消して自分のカニのイラストを表示させる
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
