using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField, TagName] string _playerTag;
    [SerializeField] int _heal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            collision.gameObject.GetComponent<PlayerMove>().Heal(_heal);
            Debug.Log("hit");
            Destroy(gameObject);
            
            
        }
    }
}
