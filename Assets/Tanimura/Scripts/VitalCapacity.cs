using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalCapacity : MonoBehaviour
{
    [Tooltip("肺活量の最大値")]
    [SerializeField] int _maxVitalCapacity;
    [Tooltip("現在の肺活量")]
    [SerializeField] int _vitalCapacity;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    /// <summary>肺活量を回復するときの関数</summary>
    /// <param name="heal"></param>
    public void VitalCapacityHeal(int heal)
    {

    }
}
