public interface IBehavior
{
    void Enter(SheepCtrl ctrl);
    void Execute(SheepCtrl ctrl);

    void Exit(SheepCtrl ctrl);
}