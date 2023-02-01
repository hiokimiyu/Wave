using System.Collections.Generic;
using UnityEngine;

public class AttackWave : MonoBehaviour
{
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] private int _damage = 1;
    [Tooltip("判定用のTag")]
    [SerializeField] private List<string> _hitTag = new();

    private float _lifeTime = 0.5f;

    private void Update()
    {
        //熱波が一定時間たったら消える処理
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //当たったオブジェクトのタグを取得して、それが炎(雪)だった時にダメージを与える
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"Hit {col.tag}");
        if (_hitTag.IndexOf(col.tag) >= 0)
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
