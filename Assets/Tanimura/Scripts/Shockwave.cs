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
    [SerializeField] GameObject _player;

　　
    void Start()
    {
       
    }

    //当たったオブジェクトのタグを取得して、それが対応しているタグならその敵の体力のスクリプトにダメージを与える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.tag == _flameTag || collision.tag == _snowTag || collision.tag == _clabTag)
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //後でカニの状態変化の処理を追加する
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
