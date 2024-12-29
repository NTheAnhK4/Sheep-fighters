using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Sheep Data", menuName = "Data/Sheep Data")]
public class SheepData : ScriptableObject
{
    public List<SheepParam> sheepData;
}

[Serializable]
public class SheepParam
{
    public string name;
    public float damage;
    public float speed;
    public float weight;
    public GameObject prefab;
}
