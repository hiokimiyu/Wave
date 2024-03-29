using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [Tooltip("対応したEnemyの体力")]
    [SerializeField] private int _hp = 0;

    public void Damage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
