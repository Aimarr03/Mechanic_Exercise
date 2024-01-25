using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected HealthSystem healthSystem;
    private bool isAlert, isAiming = false;
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
}
