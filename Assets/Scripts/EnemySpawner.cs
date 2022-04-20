using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected override void SpawnEntity()
    {
        int index = Random.Range(0, entities.Count);
        GameObject entity = entities[index];

        Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-terrainSizeX/2 + padding, terrainSizeX/2 - padding), 0, transform.position.x + Random.Range(-terrainSizeZ/2 + padding, terrainSizeZ/2 - padding));
        // distanceToPlayer = (spawnPosition - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        GameObject spawnedEntity = Instantiate(entity, spawnPosition, Quaternion.identity);

        float enemyVariablePowerScale = Random.Range(0.5f, 2f);

        spawnedEntity.transform.localScale = new Vector3(spawnedEntity.transform.localScale.x * enemyVariablePowerScale, spawnedEntity.transform.localScale.y * enemyVariablePowerScale, spawnedEntity.transform.localScale.z * enemyVariablePowerScale);
        if (enemyVariablePowerScale > 1) 
            spawnedEntity.GetComponent<Enemy>().enemy.speed /= enemyVariablePowerScale;
        
        spawnedEntity.GetComponent<Enemy>().damage *= enemyVariablePowerScale;
        spawnedEntity.GetComponent<Enemy>().damage = Mathf.Round(spawnedEntity.GetComponent<Enemy>().damage);

        spawnedEntity.GetComponent<Enemy>().health *= enemyVariablePowerScale;
        spawnedEntity.GetComponent<Enemy>().health = Mathf.Round(spawnedEntity.GetComponent<Enemy>().health);
        Debug.Log(spawnedEntity.transform.localScale);
        spawnedEntities.Add(spawnedEntity);
    }
}
