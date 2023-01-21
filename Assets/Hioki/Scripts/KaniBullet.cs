using Consts;
using UnityEngine;

public class KaniBullet : MonoBehaviour
{
    [Tooltip("��΂���")]
    [SerializeField] private float _power = 5;

    private Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        var player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).GetComponent<Transform>();
        //Player�̌����ɂ���Ĕ�΂�������ς���
        _power *= player.localScale.x > 0 ? 1 : -1;
        _rb.AddForce(transform.right * _power, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.SPAWNER_TAG))
        {
            Destroy(collision.gameObject);
        }//�X�|�i�[�ɓ������������
    }
}
