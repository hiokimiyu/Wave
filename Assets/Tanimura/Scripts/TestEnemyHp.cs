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

    //�_���[�W���󂯂đ̗͂�0�ȉ��ɂȂ����������
    public void Damage(int damage)
    {
        _enemyHp -= damage;
        if (_enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
