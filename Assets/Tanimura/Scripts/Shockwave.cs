using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField, TagName] string _flameTag;
    [SerializeField, TagName] string _snowTag;
    [SerializeField, TagName] string _clabTag;
    [SerializeField] int _damage;
    TestEnemyHp _colObjScript;
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
        if (collision.tag == _clabTag || collision.tag == _flameTag || collision.tag == _snowTag)
        {
            Debug.Log(colObj);
            _colObjScript = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjScript.Damage(_damage);
        }
    }
}
