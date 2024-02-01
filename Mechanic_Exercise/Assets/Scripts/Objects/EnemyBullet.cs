using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private int Damage = 10;
    [SerializeField] private float bulletSpeed = 40f;

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    private void Update()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += bulletSpeed * Time.deltaTime * direction;
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
