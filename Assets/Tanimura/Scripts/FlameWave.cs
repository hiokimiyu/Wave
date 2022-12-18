using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWave : MonoBehaviour
{
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] private int _damage;

    private readonly string _snowTag = "Snow";
    private float _lifeTime = 0.5f;

    private void Update()
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
        if (collision.CompareTag(_snowTag))
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
