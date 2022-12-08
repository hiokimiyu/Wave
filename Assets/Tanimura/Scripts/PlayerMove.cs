using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A,D:�ړ�
/// ���N���b�N:�U��
/// �E�N���b�N:�U���̐؂�ւ�
/// Shift:�J�j�͂�
/// Space:�W�����v
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>Rigidbody�̕ϐ�</summary>
    private Rigidbody2D _rb;
    [Tooltip("�X�s�[�h")]
    [SerializeField] private float _speed;
    [Tooltip("�W�����v�p���[")]
    [SerializeField] private float _jumpPower;
    [Tooltip("�v���C���[��HP")]
    [SerializeField] private int _playerHp;
    [Tooltip("�v���C���[�̍ő�HP")]
    [SerializeField] private int _playerMaxHp;
    [Tooltip("�v���C���[���_���[�W���󂯂����̖��G����")]
    [SerializeField] private float _godModeTime;
    [Tooltip("�v���C���[��HP�o�[")]
    [SerializeField] private Slider _hpBar;
    [Tooltip("�v���C���[�̃A�j���[�V����")]
    [SerializeField] private Animator _damageAnimation;

    private readonly string _groundTag = "Ground";
    /// <summary>�n�ʂ̐ڐG����</summary>
    private bool _isGround = true;
    /// <summary>���G���Ԕ���̕ϐ�</summary>
    private bool _isGodMode = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //HP�o�[(Slider)�̐ݒ�
        _hpBar.maxValue = _playerMaxHp;
        _hpBar.value = _playerHp;
    }

    void Update()
    {
        //�ړ��̏���
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(h * _speed, _rb.velocity.y);

        if(h != 0)
        {
            _damageAnimation.SetBool("IsWalking", true);
        }
        else
        {
            _damageAnimation.SetBool("IsWalking", false);
        }
        //�n�ʂɂ���Ƃ������W�����v����
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }

        //�i�s�����Ƀv���C���[�̌�����ς��鏈��(Transform.scale.x �́}�Ő؂�ւ���)
        var localScale = gameObject.transform.localScale;
        if (h > 0)
        {
            localScale.x = Mathf.Abs(localScale.x);
            gameObject.transform.localScale = localScale;
        }
        else if (h < 0)
        {
            localScale.x = -Mathf.Abs(localScale.x);
            gameObject.transform.localScale = localScale;
        }
    }

    //�n�ʂƂ̐ڐG����̏���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_groundTag))        
        {
            _isGround = true;
        }
    }

    //�_���[�W���󂯂鏈��
    public void Damage(int damage)
    {
        if (_isGodMode == false)
        {
            _playerHp -= damage;
            _hpBar.value = _playerHp;
            if (_playerHp <= 0)
            {
                GameObject.Find("Managers").GetComponent<GameManager>().GameOver();
                Debug.Log("GameOver�ł�");
            }
            StartCoroutine(GodMode());
            Debug.Log(_playerHp);
        }
    }

    //�A�C�e���ŉ񕜂���Ƃ��̏���
    /// <summary>
    /// �񕜃A�C�e�����Ƃ����Ƃ��ɌĂԏ���
    /// </summary>
    /// <param name="heal"> �񕜗� </param>
    public void Heal(int heal)
    {
        _playerHp += heal;
        _hpBar.value = _playerHp;
    }

    //���G���Ԃ̊ԃA�j���[�V�����𓮂����ă_���[�W���󂯂Ȃ�����
    IEnumerator GodMode()
    {
        _isGodMode = true;
        _damageAnimation.SetBool("IsDamage", true);
        yield return new WaitForSeconds(_godModeTime);
        _damageAnimation.SetBool("IsDamage", false);
        _isGodMode = false;
    }
}
