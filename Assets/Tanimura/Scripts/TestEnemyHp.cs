using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyHp : MonoBehaviour
{
    [SerializeField] int _enemyHp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ダメージを受けて体力が0以下になったら消える
    public void Damage(int damage)
    {
        _enemyHp -= damage;
        if (_enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
