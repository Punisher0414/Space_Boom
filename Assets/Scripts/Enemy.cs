using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Basic Attributes")]
    public float speed;
    public float attackRadius;
    public float visionRange;
    public float stoppingDistance;
    public int damage;
    public int rewardPoints;

    [Header("Attack Settings")]
    public float startTimeBtwAttacks;


    public virtual void Attack()
    {
        Debug.Log("Basic Attack");
    }

    public virtual void FollowPlayer()
    {
        Debug.Log("Follow Player");
    }

    public virtual void Move()
    {
        Debug.Log("Move");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, visionRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, stoppingDistance);

    }


}
