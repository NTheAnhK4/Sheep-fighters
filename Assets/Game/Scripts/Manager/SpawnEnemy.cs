
using UnityEngine;

public class SpawnEnemy : ISpawner
{
    protected override void SetSheepData(SheepCtrl sheepCtrl, int sheepId, string initAnim = "Move", IBehavior behavior = null)
    {
        sheepCtrl.Init(Vector2.left,spawnCtrl.data.sheepData[sheepId],initAnim,behavior?? new MoveHandler());
        sheepCtrl.tag = "Enemy";
        sheepCtrl.AnimCtrl.FlipAnim(false);
    }
    private Vector3 GetEnemyPosition()
    {
        float posY = spawnCtrl.verticalPoints[Random.Range(0, 5)];
        return new Vector3(spawnCtrl.MaxX, posY, 0);
    }

    protected override void Execute()
    {
        Vector3 pos = GetEnemyPosition();
        Spawn(pos,"Move", new MoveHandler());
        coolDown = 0;
    }
}
