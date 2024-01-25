using UnityEngine;

public abstract class EnemyStateManager : MonoBehaviour
{
    protected BaseState currentBaseState;
    
    public void SwitchState(BaseState newState)
    {
        currentBaseState.ExitState();
        currentBaseState = newState;
        currentBaseState.EnterState();
    }
}
