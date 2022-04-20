using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealKit : Consumable
{
    public float healPower = 50;
    public bool healPercentage = true;

    protected override void Consume(Collider other)
    {
        // If player collides with heal kit and its health is below maximum, then heal player
        if (other.gameObject.tag.Equals("Player") && other.gameObject.GetComponent<Player>().health < other.gameObject.GetComponent<Player>().maxHealth)
        {
            other.gameObject.GetComponent<Player>().Heal(healPercentage ? other.gameObject.GetComponent<Player>().maxHealth * (healPower / 100) : healPower);
            Destroy(gameObject);
        } 
        else if (other.gameObject.tag.Equals("Enemy")) // Dog can heal himself with Medical Kit && other.gameObject.name.ToLower().Contains("evildog")
        {
            other.gameObject.GetComponent<Enemy>().HealIgnoreMaxHealth(healPercentage ? other.gameObject.GetComponent<Enemy>().maxHealth * (healPower / 100) : healPower);
            other.gameObject.GetComponent<Enemy>().enemy.speed += healPower / 10 * 0.3f;
            other.gameObject.GetComponent<Enemy>().anormallyAggresive = true;
            foreach (var renderer in other.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                renderer.material.SetColor("_Color", Color.green);
            }
            Destroy(gameObject);
        }
    }
}
