using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Transform AimPosition;
    [SerializeField] private Transform Bullet;
    protected HealthSystem healthSystem;
    private bool isAlert, isAiming = false;


    public event EventHandler<Player> PlayerInVicinity;
    protected virtual void Awake()
    {
        healthSystem = new HealthSystem();
    }
    void Start()
    {
        healthSystem.HealthIsZero += HealtSystem_HealthIsZero;
    }

    private void HealtSystem_HealthIsZero(object sender, System.EventArgs e)
    {
        Debug.Log("Enemy Die");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
    public void SetAlert(bool value)
    {
        isAlert = value;
    }
    public void SetAiming(bool value)
    {
        isAiming = value;
    }
    public bool GetIsAlert()
    {
        return isAlert;
    }
    public bool GetIsAiming()
    {
        return isAiming;
    }
    public void TriggerPlayerInVicinity(Player player)
    {
        PlayerInVicinity?.Invoke(this, player);
    }
    public void GetAimComponent(out Transform aimPosition, out Transform bullet)
    {
        aimPosition = AimPosition; 
        bullet = Bullet;
    }
}
