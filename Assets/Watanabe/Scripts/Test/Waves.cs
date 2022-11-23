using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [Tooltip("当たったオブジェクトののタグ")]
    [SerializeField, TagName] string _hitTag;
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] int _damage;
    float _lifeTime = 0.5f;
    TestEnemyHp _colObjHp;

    // Update is called once per frame
    void Update()
    {
        //熱波が一定時間たったら消える処理
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _hitTag)
        {
            _colObjHp = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjHp.Damage(_damage);
        }
    }
}
