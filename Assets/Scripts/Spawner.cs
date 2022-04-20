using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Terrain terrain;

    public List<GameObject> entities;

    public float spawnCooldown;

    protected float spawnTimer;

    protected float terrainSizeX, terrainSizeZ;

    protected List<GameObject> spawnedEntities;

    public int MAX_ENTITIES = 20;

    public int MAX_SPAWNS_AT_THE_SAME_TIME = 3;

    public int padding = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        terrainSizeX = terrain.terrainData.size.x; 
        terrainSizeZ = terrain.terrainData.size.z; 
        transform.position = new Vector3(terrainSizeX / 2, 0, terrainSizeZ / 2);
        spawnTimer = 0;
        spawnedEntities = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnCooldown && spawnedEntities.Count < MAX_ENTITIES)
        {
            spawnTimer = 0;
            for (int i = 0; i < Random.Range(1, MAX_SPAWNS_AT_THE_SAME_TIME) && spawnedEntities.Count < MAX_ENTITIES; i++)
            {
                SpawnEntity();
            }
        }

        spawnedEntities.ForEach(entity =>
        {
            if (entity == null)
            {
                spawnedEntities.Remove(entity);
            }
        });
    }

    protected virtual void SpawnEntity()
    {
        int index = Random.Range(0, entities.Count);
        GameObject entity = entities[index];

        Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-terrainSizeX/2 + padding, terrainSizeX/2 - padding), 0, transform.position.x + Random.Range(-terrainSizeZ/2 + padding, terrainSizeZ/2 - padding));
        GameObject spawnedEntity = Instantiate(entity, spawnPosition, Quaternion.identity);
        spawnedEntities.Add(spawnedEntity);
    }
}
