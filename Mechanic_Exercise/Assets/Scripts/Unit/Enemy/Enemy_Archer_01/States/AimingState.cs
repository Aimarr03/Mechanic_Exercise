using UnityEngine;

public class AimingState : BaseState
{
    private _EnemyArcherStateManager stateManager;
    public AimingState(Enemy enemy, EnemyStateManager stateManager)
    {
        this.enemy = enemy;
        this.stateManager = stateManager as _EnemyArcherStateManager;   
    }
    public override void EnterState()
    {
        Debug.Log("Entering Aiming State");
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Aiming State");
    }

    public override void UpdateState()
    {
        if (!enemy.GetIsAiming()) stateManager.SwitchState(stateManager.alertState);
    }
}
