using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAggroChecker : AgroChecker
{
    protected override void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chase Aggro!");
            enemy.SetAlert(true);
        }
    }

    protected override void Start()
    {
        base.Start();
    }
}
