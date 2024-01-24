using UnityEngine;

public class AlertState : BaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        Debug.Log("Entering Alert State");
    }

    public override void ExitState(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        
    }
}
