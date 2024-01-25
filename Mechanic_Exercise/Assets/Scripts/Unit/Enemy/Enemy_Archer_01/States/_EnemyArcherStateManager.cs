using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyArcherStateManager : EnemyStateManager
{
    private _EnemyArcher enemyArcher;

    public AimingState aimingState;
    public AlertState alertState;
    public IdleState idleState;

    private _EnemyArcher _enemyArcher;
    public void Awake()
    {
        enemyArcher = GetComponent<_EnemyArcher>();
        aimingState = new AimingState(enemyArcher, this);
        alertState = new AlertState(enemyArcher, this);
        idleState = new IdleState(enemyArcher, this);
    }
    public void Start()
    {
        _enemyArcher = GetComponent<_EnemyArcher>();
        currentBaseState = idleState;
        currentBaseState.EnterState();
    }
    public void Update()
    {
        currentBaseState.UpdateState();
    }
    public Transform GetEnemyArcherTransform()
    {
        return _enemyArcher.transform;
    }
}
