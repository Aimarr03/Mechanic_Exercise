using UnityEngine;

public class AlertState : BaseState
{
    private _EnemyArcherStateManager stateManager;
    public AlertState(Enemy enemy, EnemyStateManager stateManager)
    {
        this.enemy = enemy;
        this.stateManager = stateManager as _EnemyArcherStateManager;
    }
    public override void EnterState()
    {
        Debug.Log("Entering Alert State");
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Alert State");
    }

    public override void UpdateState()
    {
        if (enemy.GetIsAiming()) stateManager.SwitchState(stateManager.aimingState);
        if (!enemy.GetIsAlert()) stateManager.SwitchState(stateManager.idleState);
    }
}
