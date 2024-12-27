using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnHandler : IBehavior
{
    

    public void Enter(SheepCtrl ctrl)
    {
        Exit(ctrl);
    }

    public void Execute(SheepCtrl ctrl)
    {
        
    }

    public void Exit(SheepCtrl ctrl)
    {
        PoolingManager.Despawn(ctrl.gameObject);
    }
}
