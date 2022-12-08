using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    [Tooltip("ç≈èIåãâ ï\é¶ÇÃText")]
    [SerializeField] private Text _resultText;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsClear == true)
        {
            _resultText.text = "GameClear!!";
        }
        else
        {
            _resultText.text = "GameOver...";
        }
    }
}
