using UnityEngine;

public class Waves : MonoBehaviour
{
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] private int _damage;

    private readonly string _hitTag = "Player";
    private float _lifeTime = 0.5f;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(_hitTag))
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
