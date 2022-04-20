using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoKit : Consumable
{
    public float ammoPower = 275;
    public bool ammoPercentage = false;

    protected override void Consume(Collider other)
    {
        // If player collides with ammo kit and its ammo is below maximum, then reload gun
        if (other.gameObject.tag.Equals("Player") && other.gameObject.GetComponentInChildren<Gun>().ammo < other.gameObject.GetComponentInChildren<Gun>().maxAmmo)
        {
            other.gameObject.GetComponentInChildren<Gun>().Reload(Mathf.RoundToInt(ammoPercentage ? other.gameObject.GetComponentInChildren<Gun>().maxAmmo * (ammoPower / 100) : ammoPower));
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("Enemy")) // Dog can boost his damage with Medical Kit  && other.gameObject.name.ToLower().Contains("evildog")
        {
            other.gameObject.GetComponent<Enemy>().damage += ammoPower * 0.15f;
            other.gameObject.GetComponent<Enemy>().enemy.speed += ammoPower / 100 * 0.15f;
            other.gameObject.GetComponent<Enemy>().anormallyAggresive = true;
            foreach (var renderer in other.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                renderer.material.SetColor("_Color", Color.blue);
            }
            Destroy(gameObject);
        }
    }
}
