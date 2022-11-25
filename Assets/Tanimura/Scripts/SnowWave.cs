using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWave : MonoBehaviour
{
    [Tooltip("炎のタグ")]
    [SerializeField, TagName] string _flameTag;
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] int _damage;
    float _lifeTime = 0.5f;
    TestEnemyHp _colObjHp;
    

        void Update()
        {
            //熱波が一定時間たったら消える処理
            _lifeTime -= Time.deltaTime;
            if (_lifeTime < 0)
            {
                Destroy(gameObject);
            }
        }
    

    //当たったオブジェクトのタグを取得して、それが雪だった時にダメージを与える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;//変数じゃなくていい
        if (collision.tag == _flameTag)
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
