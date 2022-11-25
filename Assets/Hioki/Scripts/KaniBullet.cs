using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniBullet : MonoBehaviour
{
    Rigidbody2D _rb;
    [Tooltip("飛ばす力")]
    [SerializeField] float _power = 5;
    [Tooltip("床のタグ")]
    [SerializeField, TagName] string _groundTag;
    [Tooltip("スポナーのタグ")]
    [SerializeField, TagName] string _spawnerTag;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(gameObject.transform.right * _power, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _groundTag)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == _spawnerTag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }//スポナーに当たったら消す
    }
}
