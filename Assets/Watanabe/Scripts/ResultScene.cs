using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    [Tooltip("�ŏI���ʕ\����Text")]
    [SerializeField] Text _resultText;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsClear == true)
        {
            _resultText.text = "GameClear!!";
        }
        else if (GameManager.IsClear == false)
        {
            _resultText.text = "GameOver...";
        }
    }
}
