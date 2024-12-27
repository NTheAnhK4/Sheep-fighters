using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCtrl : ParentBehavior
{
    [SerializeField] private CastleHealth health;
    [SerializeField] private float maxHp = 100f;
    protected override void OnEnable()
    {
        base.OnEnable();
        health = new CastleHealth(maxHp);
       
    }

    private void Start()
    {
        EventId eventId = EventId.AttackEnemy;
        if (transform.tag.Equals("Player")) eventId = EventId.AttackPlayer;
        ObserverManager.Attach(eventId, param =>
        {
            if (param is not float)
            {
                Debug.Log("Wrong param to castle ctrl");
                return;
            }
            health?.TakeDamage((float)param);
        });
       
    }
}
