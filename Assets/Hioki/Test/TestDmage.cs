using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damage = collision.gameObject.GetComponent<IDamage>();
        damage.Damage();
    }
}
