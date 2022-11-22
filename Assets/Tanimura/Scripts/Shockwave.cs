using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [Tooltip("炎のタグ")]
    [SerializeField, TagName] string _flameTag;
    [Tooltip("雪のタグ")]
    [SerializeField, TagName] string _snowTag;
    [Tooltip("カニのタグ")]
    [SerializeField, TagName] string _clabTag;
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] int _damage;
    TestEnemyHp _colObjHp;
    Kani _colKaniScript;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たったオブジェクトのタグを取得して、それが対応しているタグならその敵の体力のスクリプトにダメージを与える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;
        if (collision.tag == _flameTag || collision.tag == _snowTag)
        {
            Debug.Log(colObj);
            _colObjHp = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjHp.Damage(_damage);
        }
        //カニの場合はダメージではなく一発で状態を変える
        if(collision.tag == _clabTag)
        {
            _colKaniScript = collision.gameObject.GetComponent<Kani>();
            //後でカニの状態変化の処理を追加する
        }
    }
}
