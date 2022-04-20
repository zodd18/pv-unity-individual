using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    // Start is called before the first frame update

    public NavMeshAgent enemy;
    protected Transform player;


    public float damage = 10f;

    protected float defaultSpeed;

    public bool anormallyAggresive = false;

    protected void Start()
    {
        defaultSpeed = enemy.speed;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((long) Time.time < 3)
        {
            enemy.speed = 1.25f;
        }
        else if ((long) Time.time < 5)
        {
            enemy.speed = defaultSpeed;
        }
    
        if (transform.position.y < -10)
            Die();

        enemy.SetDestination(player.position);
    }
}
