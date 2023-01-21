using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [Tooltip("�Ή�����Enemy�̗̑�")]
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
