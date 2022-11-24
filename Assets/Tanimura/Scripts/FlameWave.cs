using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWave : MonoBehaviour
{
    [Tooltip("雪のタグ")]
    [SerializeField, TagName] string _SnowTag;
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] int _damage;
    float _lifeTime = 0.5f;
    TestEnemyHp _colObjHp;
    
    
    void Update()
    {
        //熱波が一定時間たったら消える処理
        _lifeTime -= Time.deltaTime;
        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    //当たったオブジェクトのタグを取得して、それが雪だった時にダメージを与える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;
        if (collision.tag == _SnowTag)
        {
            Debug.Log(colObj);
            _colObjHp = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjHp.Damage(_damage);
        }
    }
}
