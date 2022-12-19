using UnityEngine;

/// <summary>
/// “G‚ÌUŒ‚ƒNƒ‰ƒX
/// </summary>
public class Attack : MonoBehaviour
{
    [Tooltip("UŒ‚—Í")]
    [SerializeField] private int _attack;

    private readonly string _playerTag = "Player";

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            var player = collision.gameObject.GetComponent<PlayerMove>();
            player.Damage(_attack);
        }
    }
}
