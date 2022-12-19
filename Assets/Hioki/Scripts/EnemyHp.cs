using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [Tooltip("対応したエネミーの体力")]
    [SerializeField] int _hp;

    public void Damage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
