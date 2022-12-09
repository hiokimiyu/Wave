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
    /// <summary>Rigidbodyの変数</summary>
    private Rigidbody2D _rb;
    /// <summary>地面の接触判定</summary>
    private bool _isGround = true;
    /// <summary>無敵時間判定の変数</summary>
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
        //移動の処理
        float h = Input.GetAxisRaw("Horizontal");

        //移動の入力があれば「Move」のAnimationを実行する
        _anim.SetBool("IsWalking", h != 0 ? true : false);
        _rb.velocity = new Vector2(h * _moveSpeed, _rb.velocity.y);

        //地面にいるときだけジャンプする
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }

        //進行方向にプレイヤーの向きを変える処理
        //(Transform.scale.x の±で切り替える)
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

    //地面との接触判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_groundTag))        
        {
            _isGround = true;
        }
    }

    //ダメージを受ける処理
    public void Damage(int damage)
    {
        if (_isGodMode == false)
        {
            _playerHp -= damage;
            //_hpBar.value = _playerHp;

            if (_playerHp <= 0)
            {
                GameObject.Find("Managers").GetComponent<GameManager>().GameOver();
                Debug.Log("GameOverです");
            }
            StartCoroutine(GodMode());
            Debug.Log(_playerHp);
        }
    }

    //アイテムで回復するときの処理
    /// <summary>
    /// 回復アイテムをとったときに呼ぶ処理
    /// </summary>
    /// <param name="heal"> 回復量 </param>
    //public void Heal(int heal)
    //{
    //    _playerHp += heal;
    //    _hpBar.value = _playerHp;
    //}

    //無敵時間の間アニメーションを動かしてダメージを受けない処理
    IEnumerator GodMode()
    {
        _isGodMode = true;
        _anim.SetBool("IsDamage", true);
        yield return new WaitForSeconds(_godModeTime);
        _anim.SetBool("IsDamage", false);
        _isGodMode = false;
    }
}
