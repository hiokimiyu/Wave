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

    /// <summary> シーン実行中の時間 </summary>
    float _time = 0f;
    AttackType _type = AttackType.Normal;

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
        //各Listにシーン上の該当要素を追加する
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
    /// </summary>
    public void PlayerAttack()
    {

    }

    /// <summary>
    /// 攻撃の切り替え
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

    public enum AttackType
    {
        Normal,
        Warm,
        Cold
    }
}
