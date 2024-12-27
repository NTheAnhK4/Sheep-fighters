using System;
using UnityEngine;
[Serializable]
public class CastleHealth
{
    [SerializeField] private float curHp;

    public CastleHealth(float maxHp)
    {
        curHp = maxHp;
    }
    public void TakeDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            Debug.Log("I'm dead");
        }
    }
    
}