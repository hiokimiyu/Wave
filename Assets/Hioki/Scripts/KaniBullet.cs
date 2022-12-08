using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniBullet : MonoBehaviour
{
    [Tooltip("飛ばす力")]
    [SerializeField] private float _power = 5;

    private Rigidbody2D _rb;
    private readonly string _groundTag = "Ground";
    private readonly string _spawnerTag = "Spawner";

    void Start()
    {
        var player = GameObject.Find("").GetComponent<Transform>();

        _rb = GetComponent<Rigidbody2D>();

        //Playerの向きによって飛ばす方向を変える
        _power *= player.localScale.x > 0 ? 1 : -1;
        _rb.AddForce(transform.right * _power, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_groundTag))
        {
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(_spawnerTag))
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }//スポナーに当たったら消す
    }
}
