using UnityEngine;

public class SoundWave : MonoBehaviour
{
    [Tooltip("���g���^����_���[�W")]
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;

    private readonly string _crabTag = "Crab";
    private readonly string _spownerTag = "Spawner";
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = GameObject.Find("TestPlayer").transform.localScale.x * Vector2.right;
    }

    void Update()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�J�j�̏ꍇ�̓_���[�W�ł͂Ȃ��ꔭ�ŏ�Ԃ�ς���
        if (collision.CompareTag(_crabTag) || collision.CompareTag(_spownerTag))
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //��ŃJ�j�̏�ԕω��̏�����ǉ�����
        }
    }
}
