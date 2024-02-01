using UnityEngine;

public class AimingState : BaseState
{
    private _EnemyArcherStateManager stateManager;
    private Player player;
    private float attackInterval = 3f;
    private float rotationSpeed = 5;
    private float countDown = 0;
    public AimingState(Enemy enemy, EnemyStateManager stateManager)
    {
        this.enemy = enemy;
        this.stateManager = stateManager as _EnemyArcherStateManager;
        enemy.PlayerInVicinity += Enemy_PlayerInVicinity;
    }

    private void Enemy_PlayerInVicinity(object sender, Player e)
    {
        player = e;
    }

    public override void EnterState()
    {
        Debug.Log("Entering Aiming State");
        countDown = attackInterval;
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Aiming State");
    }

    public override void UpdateState()
    {
        if (!enemy.GetIsAiming()) stateManager.SwitchState(stateManager.alertState);
        if (player == null) return;
        Attacking();
    }
    private void Attacking()
    {
        if(countDown <= 0)
        {
            countDown = attackInterval;
            enemy.GetAimComponent(out Transform aimPosition, out Transform bullet);
            Transform bulletInstantiate = GameObject.Instantiate(bullet, aimPosition.position, Quaternion.identity);
            EnemyBullet enemyBullet = bulletInstantiate.GetComponent<EnemyBullet>();
            Vector3 playerPosition = player.transform.position;
            playerPosition.y = aimPosition.position.y;
            enemyBullet.Setup(playerPosition);
            
        }
        else
        {
            countDown -= Time.deltaTime;
            RotatePosition(GetDirection());
        }
    }
    private Vector3 GetDirection()
    {
        Transform playerTransform = player.transform;
        Transform enemyTransform = enemy.transform;
        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;
        return direction;
    }
    private void RotatePosition(Vector3 direction)
    {
        Quaternion rotationQuaternion = Quaternion.LookRotation(direction);
        Transform enemyTransform = enemy.transform;
        enemy.transform.rotation = Quaternion.Slerp(enemyTransform.rotation, rotationQuaternion, rotationSpeed * Time.deltaTime);
    }
}
