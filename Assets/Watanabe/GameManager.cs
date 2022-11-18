using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("���g�A�M�g��؂�ւ���^�C�~���O")]
    [SerializeField] int _switchTime = 0;

    /// <summary> �V�[�����s���̎��� </summary>
    float _time = 0f;
    /// <summary> �V�[����ɂ���G�̐� </summary>
    List<int> _sceneEnemies = new List<int>();
    /// <summary> �V�[����̃X�|�i�[�̐� </summary>
    List<int> _spawnerCount = new List<int>();
    /// <summary> �E�F�[�u�� </summary>
    int _waveCount = 0;

    /// <summary> �E�F�[�u�� </summary>
    public int WaveCount { get => _waveCount; set => _waveCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        //�eList�ɃV�[����̊Y���v�f��ǉ�����
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _switchTime)
        {
            WaveTemp();
            _time = 0f;
        }
    }

    /// <summary>
    /// ���g�A�M�g�̐؂�ւ�
    /// </summary>
    public void WaveTemp()
    {
        //enum���Ȃɂ���ݒ肵�āA�؂�ւ���?
    }
}
