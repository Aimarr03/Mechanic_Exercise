using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgroChecker : MonoBehaviour
{
    protected SphereCollider sphereCollider;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected const string PLAYER = "Player";

    protected virtual void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        Transform collisionTrigger = GetComponentInParent<Transform>();
        enemy = collisionTrigger.GetComponentInParent<Enemy>();
    }
    protected abstract void OnTriggerEnter(Collider other);
    protected virtual void OnTriggerExit(Collider other)
    {

    }

}
