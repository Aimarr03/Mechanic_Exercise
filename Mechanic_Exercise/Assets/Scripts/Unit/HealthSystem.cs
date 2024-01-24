using System;
using UnityEngine;

public class HealthSystem
{
    private int health = 100;
    public event EventHandler HealthIsZero;

    public HealthSystem()
    {
        health = 100;
    }
    public HealthSystem(int health)
    {
        this.health = health;
    }
    public bool TakeDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, 100);
        Debug.Log($"Unit remaining health: {health}");
        if(health == 0)
        {
            HealthIsZero?.Invoke(this, EventArgs.Empty);
        }
        return AliveChecker();
    }
    public bool AliveChecker()
    {
        return health > 0;
    }
}
