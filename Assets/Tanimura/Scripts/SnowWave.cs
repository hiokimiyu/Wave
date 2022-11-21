using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWave : MonoBehaviour
{
    [Tooltip("炎のタグ")]
    [SerializeField, TagName] string _flameTag;
    [Tooltip("衝撃波が与えるダメージ")]
    [SerializeField] int _damage;
    TestEnemyHp _colObjScript;
    
    void Start()
    {

    }

    
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;
        if (collision.tag == _flameTag)
        {
            Debug.Log(colObj);
            _colObjScript = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjScript.Damage(_damage);
        }
    }
}
