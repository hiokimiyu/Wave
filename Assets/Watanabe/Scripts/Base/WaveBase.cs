using UnityEngine;

public class WaveBase : MonoBehaviour
{
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] private int _damage;
    [Tooltip("判定用のTag")]
    [SerializeField] private string _hitTag;

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
        if (col.gameObject.CompareTag(_hitTag))
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
