using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("寒波、熱波を切り替えるタイミング(秒)")]
    [SerializeField, Range(1, 15)] int _switchTime = 0;
    [Tooltip("遷移先のシーン名")]
    [SerializeField, SceneName] string _sceneName;
    [Tooltip("敵をまとめておく親オブジェクト")]
    [SerializeField] GameObject _enemyParent;
    [Tooltip("スポナーをまとめておく親オブジェクト")]
    [SerializeField] GameObject _spawnerParent;
    [Tooltip("攻撃関係の音")]
    [SerializeField] AudioClip[] _attackAudio = new AudioClip[10];

    /// <summary> シーン実行中の時間 </summary>
    float _time = 0f;
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
    /// <summary> 寒波か、熱波か(false...寒波, true...熱波) </summary>
    public bool IsWarm { get; set; }
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
        //一定時間経過したら、寒波、熱波を切り替える
        _time += Time.deltaTime;
        if (_time > _switchTime)
        {
            //寒波、熱波の切り替え(false...寒波, true...熱波)
            IsWarm = IsWarm == true ? false : true;
            Debug.Log(IsWarm);
            _time = 0f;
        }

        if (SceneEnemies.Count == 0 && Spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
            //SceneManager.LoadScene(_sceneName);
        }
    }

    /// <summary>
    /// Playerの攻撃
    /// PlayerShot -> Update -> if(.....("Fire1")) の部分で呼び出す
    /// </summary>
    public void PlayerAttack()
    {
        //Animation再生?
        //SE再生(現在は適当に設定しているため、後で調整)
        _sound.AudioPlay(_attackAudio[0]);
    }

    /// <summary>
    /// 攻撃の切り替え
    /// PlayerShot -> Update -> if(.....("Fire2")) の部分で呼び出す
    /// </summary>
    public void AttackSwitch()
    {
        if (Type == AttackType.Warm)
        {
            Type = AttackType.Cold;
        }
        else if (Type == AttackType.Cold)
        {
            Type = AttackType.Warm;
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
    }
}
