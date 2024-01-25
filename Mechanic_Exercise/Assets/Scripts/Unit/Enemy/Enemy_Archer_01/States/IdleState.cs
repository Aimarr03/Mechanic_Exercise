using UnityEngine;

public class IdleState : BaseState
{
    private _EnemyArcherStateManager stateManager;
    public IdleState(Enemy enemy, EnemyStateManager stateManager)
    {
        this.enemy = enemy;
        this.stateManager = stateManager as _EnemyArcherStateManager;
    }
    public override void EnterState()
    {
        Debug.Log("Entering Idle State");
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Idle State!");
    }

    public override void UpdateState()
    {
        if (enemy.GetIsAlert()) stateManager.SwitchState(stateManager.alertState);
    }
    
}
