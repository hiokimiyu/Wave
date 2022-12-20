using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private int _heal;

    private readonly string _playerTag = "Player";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(_playerTag))
        {
            //collision.gameObject.GetComponent<PlayerMove>().Heal(_heal);
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
