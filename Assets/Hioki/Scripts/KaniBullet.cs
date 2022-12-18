using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniBullet : MonoBehaviour
{
    [Tooltip("��΂���")]
    [SerializeField] private float _power = 5;

    private readonly string _spawnerTag = "Spawner";
    private Rigidbody2D _rb;

    void Start()
    {
        var player = GameObject.Find("TestPlayer").GetComponent<Transform>();

        _rb = GetComponent<Rigidbody2D>();

        //Player�̌����ɂ���Ĕ�΂�������ς���
        _power *= player.localScale.x > 0 ? 1 : -1;
        _rb.AddForce(transform.right * _power, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_spawnerTag))
        {
            Destroy(collision.gameObject);
        }//�X�|�i�[�ɓ������������
    }
}
