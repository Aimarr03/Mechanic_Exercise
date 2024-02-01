using UnityEngine;

public class AlertState : BaseState
{
    private _EnemyArcherStateManager stateManager;
    private Player player;
    private float movementSpeed = 5f;
    private float rotationSpeed = 10f;
    public AlertState(Enemy enemy, EnemyStateManager stateManager)
    {
        this.enemy = enemy;
        this.stateManager = stateManager as _EnemyArcherStateManager;
        enemy.PlayerInVicinity += Enemy_PlayerInVicinity;
    }

    private void Enemy_PlayerInVicinity(object sender, Player e)
    {
        player = e;
        //Debug.Log(player);
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
        if (player == null) return;
        Transform playerPosition = player.transform;
        Transform enemyPosition = enemy.transform;
        Vector3 targetDirection = (playerPosition.position - enemyPosition.position).normalized;
        //Debug.Log(targetDirection);
        MovePosition(targetDirection);
        RotatePosition(targetDirection);
    }
    private void MovePosition(Vector3 direction)
    {
        enemy.transform.position += direction * Time.deltaTime * movementSpeed;
    }
    private void RotatePosition(Vector3 direction)
    {
        Quaternion rotationQuaternion = Quaternion.LookRotation(direction);
        Transform enemyTransform = enemy.transform;
        enemy.transform.rotation = Quaternion.Slerp(enemyTransform.rotation, rotationQuaternion, rotationSpeed * Time.deltaTime);
    }
}
