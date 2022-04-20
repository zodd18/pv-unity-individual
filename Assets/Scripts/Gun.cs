using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public CrosshairDetection crosshair;

    public int maxAmmo = 999;
    public int ammo = 999;

    public bool infiniteAmmo = false;

    public float damage = 15.0f;

    public float cooldownShoot = 0.15f;
    private float shootTimer;

    public float recoil = 0.35f;

    public SpriteRenderer shootEffectSpriteRenderer;

    private Quaternion defaultShootEffectRotation;

    // Start is called before the first frame update
    void Start()
    {
        shootEffectSpriteRenderer.color = new Color(0, 0, 0, 0);
        defaultShootEffectRotation = shootEffectSpriteRenderer.gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shootTimer < cooldownShoot)
        {
            shootTimer += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0) && (ammo > 0 || infiniteAmmo) && (shootTimer >= cooldownShoot))
        {
            shootTimer = 0;
            Shoot();
        }
        else if (shootTimer * 3 >= cooldownShoot)
        {
            shootEffectSpriteRenderer.color = new Color(0, 0, 0, 0);
            shootEffectSpriteRenderer.gameObject.transform.localRotation = defaultShootEffectRotation;
        }
    }

    public void Shoot()
    {

        if (!infiniteAmmo) 
            ammo--;

        shootEffectSpriteRenderer.color = new Color(255, 255, 255, 255);
        shootEffectSpriteRenderer.gameObject.transform.Rotate(0, 0, Random.Range(-10, 10));

        // GameObject.FindGameObjectWithTag("Player").transform.Rotate(0, Random.Range(-recoil, recoil), 0);

        if (crosshair.detectedEnemy != null)
        {
            if (crosshair.detectedEnemy.GetType() == typeof(SphereCollider)) // Weak Enemy Point
            {
                crosshair.detectedEnemy.GetComponent<Entity>().Damage(damage * 4);
                Debug.Log("WEAK POINT HIT");
            }
            else
            {
                crosshair.detectedEnemy.GetComponent<Entity>().Damage(damage);
            }
        }
    }

    public void Reload(int ammo)
    {
        this.ammo += ammo;
        this.ammo = Mathf.Min(this.ammo, maxAmmo);
    }
}
