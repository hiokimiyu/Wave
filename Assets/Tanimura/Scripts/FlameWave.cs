using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWave : MonoBehaviour
{
    [Tooltip("雪のタグ")]
    [SerializeField, TagName] string _SnowTag;
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] int _damage;
    TestEnemyHp _colObjScript;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //当たったオブジェクトのタグを取得して、それが雪だった時にダメージを与える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;
        if (collision.tag == _SnowTag)//
        {
            Debug.Log(colObj);
            _colObjScript = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjScript.Damage(_damage);
        }
    }
}
