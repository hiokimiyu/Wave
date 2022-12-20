using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] private int _damage;

    private readonly string _flameTag = "Flame";
    private readonly string _snowTag = "Snow";
    private readonly string _crabTag = "Crab";

    private void Start()
    {
       
    }

    //当たったオブジェクトのタグを取得して、それが対応しているタグならその敵にダメージを与える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.CompareTag(_flameTag) ||
            collision.CompareTag(_snowTag)  ||
            collision.CompareTag(_crabTag))
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //後でカニの状態変化の処理を追加する
        }
    }
}
