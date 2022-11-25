using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    [Tooltip("ç≈èIåãâ ï\é¶ÇÃText")]
    [SerializeField] Text _resultText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsClear == true)
        {
            _resultText.text = "Clear!!";
        }
        else if (GameManager.IsClear == false)
        {
            _resultText.text = "GameOver...";
        }
    }
}
