using UnityEngine;

public class IdleState : BaseState
{
    private int radius = 5;
    private int maxDistance = 50;
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        Debug.Log("Entering Idle State");
    }

    public override void ExitState(EnemyStateManager enemyStateManager)
    {
        Debug.Log("Exiting Idle State!");
    }
    public override void OnCollisionEnter(EnemyStateManager enemyStateManager)
    {
        if (!(enemyStateManager is _EnemyArcherStateManager)) return;
        _EnemyArcherStateManager enemyArcherStateManager = enemyStateManager as _EnemyArcherStateManager;
        enemyStateManager.SwitchState(enemyArcherStateManager.aimingState);
        Debug.Log("Enemy detected!");
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (!(enemyStateManager is _EnemyArcherStateManager)) return;
        Debug.Log("Enemy is not within reach!");
        _EnemyArcherStateManager enemyArcherStateManager = enemyStateManager as _EnemyArcherStateManager;

        Transform enemyArcherTransform = enemyArcherStateManager.GetEnemyArcherTransform();
        Vector3 currentDirection = enemyArcherTransform.forward;
        Vector3 currentPosition = enemyArcherTransform.position;
        Debug.Log(currentPosition);

        Collider[] colliders = Physics.OverlapSphere(currentPosition, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                //Debug.Log("Hit");
                OnCollisionEnter(enemyStateManager);
            }
        }

        /*bool gotSomething = Physics.SphereCast(currentPosition, radius, currentDirection, out RaycastHit hit);
        Debug.DrawRay(currentPosition, currentDirection * maxDistance, Color.red);
        Debug.Log($"Hit Something: {gotSomething}");*/
        /*if (!gotSomething) return;
        if(hit.transform.TryGetComponent<Player>(out Player player))
        {
            OnCollisionEnter(enemyStateManager);
        }*/
    }
    
}
