using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //オブジェクトが破壊される時、シーンから消し、Listからも削除する
    //→List.Countのズレを防ぐ
    [Tooltip("敵をまとめておく親オブジェクト")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("スポナーをまとめておく親オブジェクト")]
    [SerializeField] GameObject _spawnerParent;
    [Tooltip("攻撃関係の音")]
    [SerializeField] AudioClip[] _attackAudios = new AudioClip[10];
    [Tooltip("現在の攻撃の状態を表示するUI")]
    [SerializeField] Text _attackTypeText;

    /// <summary> 攻撃の強さ </summary>
    AttackStrength _strength = AttackStrength.Normal;
    /// <summary> 攻撃の種類 </summary>
    AttackType _type = AttackType.Cold;
    /// <summary> 音を再生するManager </summary>
    SoundManager _sound;
    /// <summary> フェードイン、アウトのクラス </summary>
    Fade _fade;
    /// <summary> 現在の攻撃状態 </summary>
    string _attackType = "音波";

    /// <summary> 敵をまとめた親オブジェクト </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> スポナーをまとめた親オブジェクト </summary>
    public GameObject SpawnerParent { get => _spawnerParent; set => _spawnerParent = value; }
    /// <summary> 攻撃の強さ </summary>
    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }
    /// <summary> 敵をまとめるList </summary>
    public List<GameObject> SceneEnemies { get; set; }
    /// <summary> スポナーをまとめるList </summary>
    public List<GameObject> Spawner { get; set; }
    /// <summary> クリアウェーブ数 </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<SoundManager>();
        _fade = GetComponent<Fade>();

        //各Listにシーン上の該当要素を追加する(最初に既に敵が存在している場合)
        //↓敵
        if (EnemyParent.transform.childCount > 0)
        {
            foreach (Transform child in EnemyParent.transform)
            {
                SceneEnemies.Add(child.gameObject);
            }
        }
        //↓スポナー
        if (SpawnerParent.transform.childCount > 0)
        {
            foreach (Transform child in SpawnerParent.transform)
            {
                Spawner.Add(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _attackTypeText.text = _attackType;

        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
            //全てのWaveをクリアしたら、リザルト画面へ遷移
            if (WaveCount == 5)
            {
                _fade.FadeStart();
            }
        }
    }

    /// <summary>
    /// Playerの攻撃
    /// PlayerShot -> Update -> if(.....("Fire1")) の部分にある程度書いてあるため
    /// +αでやりそうなことを書いておく
    /// 使わないかも?
    /// </summary>
    void PlayerAttack()
    {
        //SE再生(現在は適当に設定しているため、後で調整)
        _sound.AudioPlay(_attackAudios[0]);
    }

    /// <summary>
    /// 攻撃の切り替え
    /// PlayerShot -> Update -> if(.....("Fire2")) の部分で呼び出す
    /// UIの表示(現在の状態を可視化するため)
    /// </summary>
    public void AttackSwitch()
    {
        //現在の状態によって切り替える(順番に)
        //UI表示の処理を書く
        if (Strength == AttackStrength.Normal)
        {
            Strength = AttackStrength.Middle;
            _attackType = "ちょっと強い";
        }
        else if (Strength == AttackStrength.Middle)
        {
            if (Type == AttackType.Cold)
                Type = AttackType.Warm;
            else
                Type = AttackType.Cold;

            Strength = AttackStrength.PowerAttack;
            _attackType = "衝撃波";
        }
        else if (Strength == AttackStrength.PowerAttack)
        {
            Strength = AttackStrength.Normal;
            _attackType = "音波(普通)";
        }
    }

    /// <summary> 攻撃の強さ </summary>
    public enum AttackStrength
    {
        /// <summary> 音波(通常) </summary>
        Normal,
        /// <summary> ちょっと強いやつ </summary>
        Middle,
        /// <summary> 衝撃波 </summary>
        PowerAttack,
    }

    /// <summary> 攻撃の種類 </summary>
    public enum AttackType
    {
        /// <summary> 寒波 </summary>
        Cold,
        /// <summary> 熱波 </summary>
        Warm,
    }
}
