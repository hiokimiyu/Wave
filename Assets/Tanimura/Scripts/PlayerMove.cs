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
    Rigidbody2D _rb;
    [Tooltip("�X�s�[�h")]
    [SerializeField] float _speed;//�v���C���[�̃X�s�[�h
    [Tooltip("�W�����v�p���[")]
    [SerializeField] float _jumpPower;//�v���C���[�̃W�����v�p���[
    [Tooltip("�v���C���[��HP")]
    [SerializeField] int _playerHp;//�v���C���[��HP
    [Tooltip("�v���C���[�̍ő�HP")]
    [SerializeField] int _playerMaxHp;
    [Tooltip("�v���C���[�̔x����")]
    [SerializeField] float _vitalCapacity;//�v���C���[�̔x����
    [Tooltip("�v���C���[���_���[�W���󂯂����̖��G����")]
    [SerializeField] float _godModeTime;
    [Tooltip("�v���C���[��HP�o�[")]
    [SerializeField] Slider _hpBar;
    [Tooltip("�v���C���[�̃A�j���[�V����")]
    [SerializeField] Animator _damageAnimation;
    [Tooltip("Ground�^�O")]
    [SerializeField, TagName] string _groundTag;
    
    /// <summary>�n�ʂ̐ڐG����</summary>
    bool _isGround = true;//�n�ʂ̐ڐG����̕ϐ�
    /// <summary>���G���Ԕ���̕ϐ�</summary>
    bool _isGodMode = false;

    /// <summary>�v���C���[��HP</summary>
    public int PlayerHp { get => _playerHp; set => _playerHp = value; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //HP�o�[�̐ݒ�
        _hpBar.maxValue = _playerMaxHp;
        _hpBar.value = _playerHp;
    }

    void Update()
    {
        //�ړ��̏���
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(h, _rb.velocity.y);
        //�n�ʂɂ���Ƃ������W�����v����
        if (Input.GetButtonDown("Jump")�@&& _isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }
        
        //�i�s�����Ƀv���C���[�̌�����ς��鏈��
        transform.eulerAngles = h < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
    }
        

    //�n�ʂƂ̐ڐG����̏���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _groundTag)
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
            StartCoroutine(GodMode());
        }
    }

    //�A�C�e���ŉ񕜂���Ƃ��̏���
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
