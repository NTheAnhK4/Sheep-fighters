using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : IBehavior
{
    public void Enter(SheepCtrl ctrl)
    {
        
    }

    public void Execute(SheepCtrl ctrl)
    {
        EventId eventId = (ctrl.transform.tag.Equals("Player")) ? EventId.AttackEnemy : EventId.AttackPlayer;
        ObserverManager.Notify(eventId,ctrl.Damage);
        ctrl.ChangeBehavior(new DespawnHandler());
    }

    public void Exit(SheepCtrl ctrl)
    {
       
    }
}
