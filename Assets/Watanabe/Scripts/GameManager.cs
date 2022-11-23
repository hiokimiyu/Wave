using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("敵をまとめておく親オブジェクト")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("スポナーをまとめておく親オブジェクト")]
    [SerializeField] GameObject _spawnerParent;
    [Tooltip("攻撃関係の音")]
    [SerializeField] AudioClip[] _attackAudios = new AudioClip[10];

    /// <summary> 攻撃の種類 </summary>
    AttackType _type = AttackType.Normal;
    /// <summary> 音を再生するManager </summary>
    SoundManager _sound;

    /// <summary> シーン上の敵をまとめた親オブジェクト </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> シーン上のスポナーをまとめた親オブジェクト </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    public AttackType Type { get => _type; set => _type = value; }
    /// <summary> シーン上にいる敵 </summary>
    public List<GameObject> SceneEnemies { get; set; }
    /// <summary> シーン上のスポナー </summary>
    public List<GameObject> Spawner { get; set; }
    /// <summary> ウェーブ数 </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<SoundManager>();

        //各Listにシーン上の該当要素を追加する(最初に既に敵が存在している場合)
        //↓敵
        foreach (Transform child in EnemyParent.transform)
        {
            SceneEnemies.Add(child.gameObject);
        }
        //↓スポナー
        foreach (Transform child in SpawnerParent.transform)
        {
            Spawner.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
        }
    }

    /// <summary>
    /// Playerの攻撃
    /// PlayerShot -> Update -> if(.....("Fire1")) の部分にある程度書いてあるため、
    /// +αでやりそうなことを書いておく
    /// </summary>
    void PlayerAttack()
    {
        //SE再生(現在は適当に設定しているため、後で調整)
        _sound.AudioPlay(_attackAudios[0]);
    }

    /// <summary>
    /// 攻撃の切り替え
    /// PlayerShot -> Update -> if(.....("Fire2")) の部分で呼び出す
    /// </summary>
    public void AttackSwitch()
    {
        //現在の状態によって切り替える(順番に)
        if (Type == AttackType.Normal)
        {
            Type = AttackType.Warm;
        }
        else if (Type == AttackType.Warm)
        {
            Type = AttackType.Cold;
        }
        else if (Type == AttackType.Cold)
        {
            Type = AttackType.PowerAttack;
        }
        else if (Type == AttackType.PowerAttack)
        {
            Type = AttackType.Normal;
        }
    }

    /// <summary> 攻撃の種類 </summary>
    public enum AttackType
    {
        /// <summary> 音波(通常) </summary>
        Normal,
        /// <summary> 寒波 </summary>
        Cold,
        /// <summary> 熱波 </summary>
        Warm,
        /// <summary> 衝撃波 </summary>
        PowerAttack,
    }
}
