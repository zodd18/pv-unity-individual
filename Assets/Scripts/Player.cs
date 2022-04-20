using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    // Start is called before the first frame update

    public CharacterController controller;

    public float cooldownDamage;

    private bool canBeDamaged;
    private float damageTimer;

    void Start()
    {
        canBeDamaged = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canBeDamaged && damageTimer >= cooldownDamage)
        {
            canBeDamaged = true;
        }

        if (!canBeDamaged)
        {
            damageTimer += Time.deltaTime;
        }
        
        // if (transform.position.y < -10)
        //     Die();
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Enemy" && canBeDamaged) {
            float damageDealt = other.gameObject.GetComponent<Enemy>().damage;
            Damage(damageDealt);

            restartDamageTimer();    
        }
    }

    private void restartDamageTimer()
    {
        canBeDamaged = false;
        damageTimer = 0;
    }
}
