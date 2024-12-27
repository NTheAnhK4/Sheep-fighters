using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveHandler : IBehavior
{
   
   

    public void Enter(SheepCtrl ctrl)
    {
        
    }

    public void Execute(SheepCtrl ctrl)
    {
        ctrl.Rigid.AddForce(ctrl.Direction * ctrl.MoveSpeed);
    }

    public void Exit(SheepCtrl ctrl)
    {
        
    }
}
