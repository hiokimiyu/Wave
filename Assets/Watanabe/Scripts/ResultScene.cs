using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    [Tooltip("最終結果表示のText")]
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
