using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAggroChecker : AgroChecker
{
    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Aiming Aggro!");
            enemy.SetAiming(true);
            
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Aiming Aggro!");
            enemy.SetAiming(false);
        }
    }

    protected override void Start()
    {
        base.Start();
    }
}
