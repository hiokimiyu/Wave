using UnityEngine;

/// <summary>
/// 寒波、熱波を切り替える
/// </summary>
public class SwitchWave : MonoBehaviour
{
    private readonly string _enterTag = "Player";
    private AttackStatus _status;

    private void Start()
    {
        _status = GetComponent<AttackStatus>();
    }

    void Switch()
    {
        //切り替えオブジェクトに触れた時に寒波、熱波を切り替える
        if (_status.Type == AttackStatus.AttackType.Cold)
        {
            _status.Type = AttackStatus.AttackType.Warm;
        }
        else if (_status.Type == AttackStatus.AttackType.Warm)
        {
            _status.Type = AttackStatus.AttackType.Cold;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("切り替えます");
        //切り替えオブジェクトに入ってきたのがPlayerだったら
        if (col.CompareTag(_enterTag))
        {
            //寒波、熱波を切り替える
            Switch();
        }
    }
}
