using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("���g�A�M�g��؂�ւ���^�C�~���O(�b)")]
    [SerializeField, Range(1, 15)] int _switchTime = 0;
    [Tooltip("�J�ڐ�̃V�[����")]
    [SerializeField, SceneName] string _sceneName;
    [Tooltip("�G���܂Ƃ߂Ă����e�I�u�W�F�N�g")]
    [SerializeField] GameObject _enemyParent;

    /// <summary> �V�[�����s���̎��� </summary>
    float _time = 0f;
    /// <summary> �V�[����ɂ���G </summary>
    [SerializeField] List<GameObject> _sceneEnemies = new List<GameObject>();
    /// <summary> �V�[����̃X�|�i�[ </summary>
    List<GameObject> _spawner = new List<GameObject>();

    /// <summary> �V�[����̓G���܂Ƃ߂��e�I�u�W�F�N�g </summary>
    public GameObject EnemyParent { get => _enemyParent; set => _enemyParent = value; }
    /// <summary> ���g���A�M�g���̐؂�ւ� </summary>
    public WaveMode Type { get; set; }
    /// <summary> �E�F�[�u�� </summary>
    public int WaveCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //�eList�ɃV�[����̊Y���v�f��ǉ�����
        foreach (Transform child in EnemyParent.transform)
        {
            _sceneEnemies.Add(child.gameObject);
        }
        Type = WaveMode.Warm;
    }

    // Update is called once per frame
    void Update()
    {
        //��莞�Ԍo�߂�����A���g�A�M�g��؂�ւ���
        _time += Time.deltaTime;
        if (_time > _switchTime)
        {
            WaveTemp();
            _time = 0f;
            if (_sceneEnemies.Count != 0)
            {
                Destroy(_sceneEnemies[0]);
                _sceneEnemies.Remove(_sceneEnemies[0]);
            }
        }

        if (_sceneEnemies.Count == 0 && _spawner.Count == 0)
        {
            WaveCount++;
            Debug.Log(WaveCount);
            SceneManager.LoadScene(_sceneName);
        }
    }

    /// <summary>
    /// ���g�A�M�g�̐؂�ւ�
    /// </summary>
    public void WaveTemp()
    {
        Type = Type == WaveMode.Warm ? WaveMode.Cold : WaveMode.Warm;
    }

    public enum WaveMode
    {
        Warm,
        Cold,
    }
}
