using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kani : MonoBehaviour, IDamage
{
    [Tooltip("移動スピード")]
    [SerializeField] private float _speed = 5;
    [Tooltip("かにの状態")]
    [SerializeField] private bool _isStop;
    [Tooltip("かにが消える時間")]
    [SerializeField] private float _deleteTime = 3;

    /// <summary>ひっくり返るときの回転数値</summary>
    private float _rotateZ = 0;
    private readonly string _wallTag ="Wall";
    private readonly string _bossTag = "Boss";
    private Rigidbody2D _rb;
    private SoundManager _soundManager;
    /// <summary>攻撃なくす</summary>
    private Attack _attack;

    //テストしやすいように見えるようにしておくもの↓

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _attack = GetComponent<Attack>();
        _soundManager = GameObject.Find("Managers").GetComponent<SoundManager>();

        //自分がどっち向いてるか確認して、進む方向を決めてる
        _speed *= transform.eulerAngles.y == 180 ? 1 : -1;
    }

    void Update()
    {
        if (!_isStop)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }//動ける状態
        else if (_isStop)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _rotateZ = 180;
            _deleteTime -= Time.deltaTime;

            if (_deleteTime < 0)
            {
                Destroy(gameObject);
            }//時間になったら消す
        }//動けない状態

        //方向転換
        transform.eulerAngles = _speed < 0 ? new Vector3(0, 180, _rotateZ) : new Vector3(0, 0, _rotateZ);
    }

    void IDamage.Damage()
    {
        //かにがストップする
        _isStop = true;
        _attack.enabled = false;
        _soundManager.AudioPlay(_soundManager.AttackAudios[4]);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //かべ、自分と同じタグに当たったら
        if (col.gameObject.CompareTag(_wallTag) || col.gameObject.CompareTag(gameObject.tag))
        {
            _speed *= -1f;
        }//方向転換

        if (col.gameObject.CompareTag(_bossTag))
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
