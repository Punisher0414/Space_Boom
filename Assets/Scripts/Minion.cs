using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Minion : Enemy
{
    [Header("Minion Attributes")]
    //[SerializeField]
    //private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
    private Transform playerPosition;
    private AIDestinationSetter aiDestinationSetter;
    private GameObject initialPosition;
    private Transform initialPositionRoot;
    private PlayerHealth playerHealth;
    private float timeBtwAttacks;


    public void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        initialPositionRoot = GameObject.FindGameObjectWithTag("InitialPositionRoot").GetComponent<Transform>();
        initialPosition = new GameObject(this.gameObject.name + "_Initial_Positon");
        initialPosition.transform.position = this.transform.position;
        initialPosition.transform.SetParent(initialPositionRoot);
        
    }


    private void FixedUpdate()
    {
        FollowPlayer();
        if (timeBtwAttacks > 0F)
        {
            timeBtwAttacks -= Time.deltaTime;
        }

    }
    public override void FollowPlayer()
    {
        if (Vector2.Distance(this.transform.position, playerPosition.position) <= visionRange)
        {
            //Vector2 dir = new Vector2(playerPosition.position.x - this.transform.position.x, playerPosition.position.y - this.transform.position.y);
            //dir = dir.normalized * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + dir);
            if (Vector2.Distance(this.transform.position, playerPosition.position) > stoppingDistance)
            {
                aiDestinationSetter.target = playerPosition;
            }
            else
            {
                aiDestinationSetter.target = null;
            }

            if (Vector2.Distance(this.transform.position, playerPosition.position) <= attackRadius  && timeBtwAttacks <= 0F)
            {
                Attack(); 
            }
        }
        else
        {
            aiDestinationSetter.target = initialPosition.transform;
        }
    }

    public override void Attack()
    {
        playerHealth.TakeDamage(damage);
        timeBtwAttacks = startTimeBtwAttacks;
    }
}
