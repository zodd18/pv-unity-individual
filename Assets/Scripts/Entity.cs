using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        HealIgnoreMaxHealth(heal);
        health = Mathf.Min(maxHealth, health);
    }

    public void HealIgnoreMaxHealth(float heal)
    {
        health += heal;
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
