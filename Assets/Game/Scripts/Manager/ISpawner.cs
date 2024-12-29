
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class ISpawner : ChildBehavior
{
    [SerializeField] protected SpawnCtrl spawnCtrl;
    [SerializeField] protected float timerSpawn = 5f;
    [SerializeField] protected float coolDown;


   

    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (spawnCtrl == null) spawnCtrl = transform.GetComponentInParent<SpawnCtrl>();
        timerSpawn = 5f;
        coolDown = 0f;
    }

    protected void Spawn(Vector3 position, string initAnim = "Move", IBehavior behavior = null)
    {
        int sheepId = Random.Range(0, spawnCtrl.data.sheepData.Count);
        SheepCtrl sheepCtrl = PoolingManager.Spawn(spawnCtrl.data.sheepData[sheepId].prefab, position, default, spawnCtrl.Holder)
            .GetComponent<SheepCtrl>();
        SetSheepData(sheepCtrl, sheepId, initAnim, behavior);
    }

    protected abstract void SetSheepData(SheepCtrl sheepCtrl, int sheepId, string initAnim = "Move", IBehavior behavior = null);
    protected abstract void Execute();
    protected virtual void Update()
    {
        coolDown += Time.deltaTime;
        if(coolDown < timerSpawn) return;
        Execute();
    }
}
