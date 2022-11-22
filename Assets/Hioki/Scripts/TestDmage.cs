using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDmage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var _d = collision.gameObject.GetComponent<IDamage>();
        _d.Dmage();
    }
}
