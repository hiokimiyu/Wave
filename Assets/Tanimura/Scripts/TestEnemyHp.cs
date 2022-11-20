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

    //ƒ_ƒ[ƒW‚ğó‚¯‚Ä‘Ì—Í‚ª0ˆÈ‰º‚É‚È‚Á‚½‚çÁ‚¦‚é
    public void Damage(int damage)
    {
        _enemyHp -= damage;
        if (_enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
