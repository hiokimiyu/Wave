using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Status")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private int _maxHP;
    [SerializeField] private float _godModeTime;

    private readonly string _groundTag = "Ground";
    private int _playerHp;
    private Animator _anim;
    /// <summary>Rigidbody�̕ϐ�</summary>
    private Rigidbody2D _rb;
    /// <summary>�n�ʂ̐ڐG����</summary>
    private bool _isGround = true;
    /// <summary>���G���Ԕ���̕ϐ�</summary>
    private bool _isGodMode = false;

    public int PlayerHP { get => _playerHp; set => _playerHp = value; }

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        _playerHp = _maxHP;
    }

    private void Update()
    {
        //�ړ��̏���
        float h = Input.GetAxisRaw("Horizontal");

        //�ړ��̓��͂�����΁uMove�v��Animation�����s����
        _anim.SetBool("IsWalking", h != 0 ? true : false);
        _rb.velocity = new Vector2(h * _moveSpeed, _rb.velocity.y);

        //�n�ʂɂ���Ƃ������W�����v����
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }

        //�i�s�����Ƀv���C���[�̌�����ς��鏈��
        //(Transform.scale.x �́}�Ő؂�ւ���)
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
            //_hpBar.value = _playerHp;

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
    //public void Heal(int heal)
    //{
    //    _playerHp += heal;
    //    _hpBar.value = _playerHp;
    //}

    //���G���Ԃ̊ԃA�j���[�V�����𓮂����ă_���[�W���󂯂Ȃ�����
    IEnumerator GodMode()
    {
        _isGodMode = true;
        _anim.SetBool("IsDamage", true);
        yield return new WaitForSeconds(_godModeTime);
        _anim.SetBool("IsDamage", false);
        _isGodMode = false;
    }
}
