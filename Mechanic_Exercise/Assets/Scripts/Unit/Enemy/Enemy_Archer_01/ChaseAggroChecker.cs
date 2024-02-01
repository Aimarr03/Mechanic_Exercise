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
            Player player = collider.gameObject.GetComponent<Player>();
            enemy.TriggerPlayerInVicinity(player);
        }
    }
    private void OnTriggerStay(Collider other)
    {
            
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chase Aggro!");
            enemy.SetAlert(false);
            enemy.TriggerPlayerInVicinity(null);
        }
    }

    protected override void Start()
    {
        base.Start();
    }
}
