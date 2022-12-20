using UnityEngine;

public class WaveBase : MonoBehaviour
{
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] private int _damage;
    [Tooltip("����p��Tag")]
    [SerializeField] private string _hitTag;

    private float _lifeTime = 0.5f;

    private void Update()
    {
        //�M�g����莞�Ԃ�����������鏈��
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ��(��)���������Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"Hit {col.tag}");
        if (col.gameObject.CompareTag(_hitTag))
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
