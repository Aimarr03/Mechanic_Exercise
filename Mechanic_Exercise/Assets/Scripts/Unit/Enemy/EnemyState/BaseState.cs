public abstract class BaseState
{
    protected Enemy enemy;
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
