using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalCapacity : MonoBehaviour
{
    [Tooltip("”xŠˆ—Ê‚ÌÅ‘å’l")]
    [SerializeField] float _maxVitalCapacity;
    [Tooltip("Œ»İ‚Ì”xŠˆ—Ê")]
    [SerializeField] float _vitalCapacity;
    [Tooltip("”xŠˆ—Ê‚Ì‰ñ•œ—Ê")]
    [SerializeField] float _recoveryAmount;
    [Tooltip("”xŠˆ—Êƒo[")]
    [SerializeField] Slider _vitalCapacityBar;
    /// <summary>‰ñ•œ‚Å‚«‚é‚©‚Ç‚¤‚©‚Ì”»’è</summary>
    bool _isRecovery = true;
    /// <summary>‰ñ•œ‚Å‚«‚é‚©‚Ç‚¤‚©‚Ì”»’è‚ÌƒvƒƒpƒeƒB</summary>
    public bool IsRecovery{ get => _isRecovery; set => _isRecovery = value; }


void Start()
    {
        //”xŠˆ—Ê‚ÆMax”xŠˆ—Ê‚Ìİ’è
        _vitalCapacityBar.maxValue = _maxVitalCapacity;
        _vitalCapacityBar.value = _vitalCapacity;
    }

    void Update()
    {
        _vitalCapacityBar.value = _vitalCapacity;
        //‰ñ•œó‘Ô‚É‚È‚Á‚½‚ç”xŠˆ—Ê‚ğ‰ñ•œ‚·‚é
        if (_isRecovery)
        {
            _vitalCapacity += _recoveryAmount;
            //Å‘å’lˆÈã‚É‚È‚ç‚È‚¢‚æ‚¤‚É‚·‚éˆ—
            if (_vitalCapacity > _maxVitalCapacity)
            {
                _vitalCapacity = _maxVitalCapacity;
            }
        }


    }
    
    /// <summary>”xŠˆ—Ê‚ğ‰ñ•œƒAƒCƒeƒ€‚Å‰ñ•œ‚·‚é‚Æ‚«‚ÌŠÖ”</summary>
    /// <param name="heal"></param>
    public void VitalCapacityHeal(int heal)
    {
        _vitalCapacity += heal;
        if(_vitalCapacity > _maxVitalCapacity)
        {
            _vitalCapacity = _maxVitalCapacity;
        }
    }

    /// <summary>UŒ‚‚ğo‚·‚Æ‚«‚É”xŠˆ—Ê‚ª‘«‚è‚Ä‚¢‚½‚çtrue,‘«‚è‚Ä‚¢‚È‚©‚Á‚½‚çfalse‚ğ•Ô‚·</summary>
    /// <param name="use"></param>
    /// <returns></returns>
    public bool VitalCapacityUse(int use)
    {
        if(_vitalCapacity < use)
        {
            return false;
        }
        else
        {
            _vitalCapacity -= use;
            return true;
        }
    }
}
