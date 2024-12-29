using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerSheep : ISpawner
{
    private SheepCtrl playerSheep;
    

    private void OnEnable()
    {
        ObserverManager.Attach(EventId.PlayerSheepPosition, param =>
        {
            // exit a sheep
            if (playerSheep != null)
            {
                Debug.Log("A sheep has already existed on the ground");
                return;
            }
            Vector3 spawnPos = new Vector3(spawnCtrl.MinX, spawnCtrl.verticalPoints[(int)param], 0);
            if (!CanSpawnSheep(spawnPos))
            {
                Debug.Log("There is a sheep here");
                return;
            }
            Spawn(spawnPos,"Idle", new IdleHandler());
        });
    }


    private void OnDisable()
    {
        ObserverManager.Detach(EventId.PlayerSheepPosition, param =>
        {
            // exit a sheep
            if (playerSheep != null) return;
            Vector3 spawnPos = new Vector3(spawnCtrl.MinX, spawnCtrl.verticalPoints[(int)param], 0);
            Spawn(spawnPos,"Idle", new IdleHandler());
        });
    }

    protected override void SetSheepData(SheepCtrl sheepCtrl, int sheepId, string initAnim = "Move", IBehavior behavior = null)
    {
        sheepCtrl.Init(Vector2.right,spawnCtrl.data.sheepData[sheepId],initAnim, behavior?? new MoveHandler());
        sheepCtrl.tag = "Player";
        sheepCtrl.AnimCtrl.FlipAnim(true);

        playerSheep = sheepCtrl;
    }

    private bool CanSpawnSheep(Vector3 sheepPosition)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(sheepPosition + new Vector3(-1, 0, 0), Vector2.right, 2);
        return raycastHit2D.collider == null;
    }
    protected override void Execute()
    {
        coolDown = 0;
        //If doesn't have any sheep
        if(playerSheep == null ) return;
        playerSheep.ChangeBehavior(new MoveHandler());
        playerSheep.ChangeAnim("Move");
        playerSheep = null;
    }

    
}
