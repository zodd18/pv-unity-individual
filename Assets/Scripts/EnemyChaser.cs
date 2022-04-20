using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaser : Enemy
{
    private Transform target;
    private Vector3 targetPosition;

    public float randomMovementFactor = 7f;

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
        else if (player.gameObject.GetComponent<Player>().health <= player.gameObject.GetComponent<Player>().maxHealth * 0.5)
        {
            enemy.speed = defaultSpeed * 1.5f;
        }

        GameObject[] consumables = GameObject.FindGameObjectsWithTag("Consumable");
        if (anormallyAggresive || consumables.Length <= 0) // Chase player
        {
            Vector3 playerPosition = player.position;

            Vector3 distanceToPlayer = (playerPosition - transform.position);
            if (Mathf.Abs(distanceToPlayer.x) > 10 && Mathf.Abs(distanceToPlayer.y) > 10 ) 
            {
                playerPosition.x = playerPosition.x + Random.Range(-randomMovementFactor, randomMovementFactor);
                playerPosition.z = playerPosition.z + Random.Range(-randomMovementFactor, randomMovementFactor);
            }

            target = player;
            targetPosition = playerPosition;
        }
        else if (!anormallyAggresive && ((consumables.Length > 0 && target == null) || (target != null && target.gameObject.tag != "Consumable" && consumables.Length > 0))) // Chase consumable
        {
            target = (consumables.GetValue(Random.Range(0, consumables.Length)) as GameObject).transform;
            targetPosition = target.position;
        }

        enemy.SetDestination(targetPosition); 

        if (transform.position.y < -10)
            Die();
    }
}
