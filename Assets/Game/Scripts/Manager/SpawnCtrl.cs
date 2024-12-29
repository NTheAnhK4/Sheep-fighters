using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : Singleton<SpawnCtrl>
{
    public SheepData data;
    public List<float> verticalPoints;
    [SerializeField] protected Transform holder;
    [SerializeField] protected float maxX;
    [SerializeField] protected float minX;

    public Transform Holder => holder;

    public float MaxX => maxX;

    public float MinX => minX;

    protected override void Awake()
    {
        base.Awake();
        if (holder == null)
        {
            holder = GameObject.Find("Actor Holder")?.transform;
            GameObject newHolder = new GameObject("Actor Holder");
            if (holder == null) holder = newHolder.transform;
        }
    }
}
