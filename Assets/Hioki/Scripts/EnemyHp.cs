using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [Tooltip("‘Î‰ž‚µ‚½Enemy‚Ì‘Ì—Í")]
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
