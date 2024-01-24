public abstract class BaseState
{
    public abstract void EnterState(EnemyStateManager enemyStateManager);
    public abstract void UpdateState(EnemyStateManager enemyStateManager);
    public abstract void ExitState(EnemyStateManager enemyStateManager);

    public abstract void OnCollisionEnter(EnemyStateManager enemyStateManager);
}
