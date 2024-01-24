using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyArcherStateManager : EnemyStateManager
{
    public AimingState aimingState = new AimingState();
    public AlertState alertState = new AlertState();
    public IdleState idleState = new IdleState();

    private _EnemyArcher _enemyArcher;
    public void Start()
    {
        _enemyArcher = GetComponent<_EnemyArcher>();
        currentBaseState = idleState;
        currentBaseState.EnterState(this);
    }
    public void Update()
    {
        currentBaseState.UpdateState(this);
    }
    public Transform GetEnemyArcherTransform()
    {
        return _enemyArcher.transform;
    }
}
