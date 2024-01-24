using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int movementSpeed = 15;

    private HealthSystem healthSystem;
    private PlayerController playerController;
    private void Awake()
    {
        #region Creating an instance of classes
        healthSystem = new HealthSystem(100);
        playerController = new PlayerController();
        #endregion


    }
    void Start()
    {
        healthSystem.HealthIsZero += HealthSystem_HealthIsZero;
        playerController.Player.Enable();
    }

    private void HealthSystem_HealthIsZero(object sender, System.EventArgs e)
    {
        Debug.Log("Unit Dies");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && healthSystem.AliveChecker())
        {
            TakeDamage(10);
        }
        BasicMovement();
    }
    public void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
    }
    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
    private Vector3 GetNormalizedMoveDirection()
    {
        Vector2 movementDirectionVector2 = playerController.Player.BasicMovement.ReadValue<Vector2>();
        Vector3 movementDirectionVector3 = new Vector3(movementDirectionVector2.x, 0, movementDirectionVector2.y);
        return movementDirectionVector3;
    }
    private void BasicMovement()
    {
        Vector3 movementDirection = GetNormalizedMoveDirection();
        //Debug.Log(movementDirection);
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
    }
}
