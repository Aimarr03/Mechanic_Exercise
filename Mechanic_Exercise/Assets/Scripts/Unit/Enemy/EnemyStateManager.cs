using UnityEngine;

public abstract class EnemyStateManager : MonoBehaviour
{
    protected BaseState currentBaseState;
    
    public void SwitchState(BaseState newState)
    {
        currentBaseState.ExitState(this);
        currentBaseState = newState;
        currentBaseState.EnterState(this);
    }
}
