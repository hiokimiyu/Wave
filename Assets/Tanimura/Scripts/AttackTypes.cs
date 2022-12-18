using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypes : MonoBehaviour
{
    [SerializeField] private GameObject[] _soundWave;
    [SerializeField] private GameObject[] _flameWave;
    [SerializeField] private GameObject[] _snowWave;
    [SerializeField] private GameObject[] _shockWave;
    [Tooltip("音波の消費肺活量")]
    [SerializeField] private int _soundWaveCost;
    [Tooltip("衝撃波の消費肺活量")]
    [SerializeField] private int _shockWaveCost;
    [Tooltip("温度波の消費肺活量")]
    [SerializeField] private int _temperatureWaveCost;
    [Tooltip("カニの弾の子オブジェクト")]
    [SerializeField] private GameObject _crabBullet;
    [Tooltip("カニを追っているかどうかの判定")]
    [SerializeField] private bool _isKaniCatch = false;

    /// <summary>射程距離のレベル</summary>
    private int _rangeLV = 0;
    /// <summary> 孫オブジェクト(カニのイラスト) </summary>
    private GameObject _grandChild;
    private GameObject _player;
    private GameObject _muzzle;

    private KaniCatch _kaniCatchJudge;
    private VitalCapacity _healJudge;
    private AttackStatus _attackStatus;

    /// <summary>射程距離のレベルのプロパティ</summary>
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }

    void Start()
    {
        _player = GameObject.Find("TestPlayer");

        _muzzle = _player.transform.GetChild(0).gameObject;
        _grandChild = _muzzle.GetComponent<Transform>().transform.GetChild(0).gameObject;

        _kaniCatchJudge = _muzzle.GetComponent<KaniCatch>();
        _healJudge = _player.GetComponent<VitalCapacity>();
        _attackStatus = GameObject.Find("Switch").GetComponent<AttackStatus>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //カニを持っていたらそのまま飛ばす
            if (_kaniCatchJudge.CrabIllust.activeSelf)
            {
                Debug.Log("Throw crab away");
                //投げる処理
                Instantiate(_crabBullet, _muzzle.transform.position, Quaternion.identity);
                //カニを投げた後に手元のカニの表示を消す
                _grandChild.SetActive(false);
            }
            else
            {
                Debug.Log("Wave attack");
                //攻撃種類の判定,音波
                switch (_attackStatus.Strength)
                {
                    case AttackStatus.AttackStrength.Normal:
                        NormalAttack();
                        break;
                    case AttackStatus.AttackStrength.Middle:
                        MiddleAttack();
                        break;
                    case AttackStatus.AttackStrength.PowerAttack:
                        PowerAttack();
                        break;
                }
            }
        }
        //攻撃切り替えの入力受付
        if (Input.GetButtonDown("Fire2"))
        {
            _attackStatus.AttackSwitch();
        }
    }

    private void NormalAttack()
    {
        //肺活量が足りているかの判定
        if (_healJudge.VitalCapacityUse(_soundWaveCost))
        {
            Debug.Log("LeftClick");
            //音波の飛ばす処理
            Instantiate(_soundWave[_rangeLV], _player.transform.position, Quaternion.identity);
            StartCoroutine(IsRecovery(1f));
        }
    }

    private void MiddleAttack()
    {
        //肺活量が足りているかの判定
        if (_healJudge.VitalCapacityUse(_temperatureWaveCost))
        {
            GameObject shot;

            if (_attackStatus.Type == AttackStatus.AttackType.Warm)
            {
                //自分の位置からマウスの位置に向かって熱波を出す
                shot = Instantiate(_flameWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                //自分の位置からマウスの位置に向かって寒波を出す
                shot = Instantiate(_snowWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
            }

            var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
            var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
            shot.transform.localRotation = rotation;
            StartCoroutine(IsRecovery(1f));
        }
    }

    private void PowerAttack()
    {
        if (_healJudge.VitalCapacityUse(_shockWaveCost))
        {
            Instantiate(_shockWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
            StartCoroutine(IsRecovery(1f));
        }
    }

    /// <summary> 攻撃後 stopHeal秒 肺活量の回復を止めて、また再開する処理 </summary>
    IEnumerator IsRecovery(float stopHeal)
    {
        _healJudge.IsRecovery = false;
        yield return new WaitForSeconds(stopHeal);
        _healJudge.IsRecovery = true;
    }
}
