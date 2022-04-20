using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairDetection : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public Collider detectedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);

        if (Physics.Raycast(ray, out hit, 100))
        {
            detectedEnemy = hit.collider;

            if (detectedEnemy.GetType() == typeof(SphereCollider)) // Weak Enemy Point
            {
                spriteRenderer.gameObject.transform.localScale = new Vector3(0.006f, 0.01f, 0);
                Debug.Log("Weak Enemy Point");
            }
            else
            {
                spriteRenderer.gameObject.transform.localScale = new Vector3(0.0085f, 0.015f, 0);
            }


            if (detectedEnemy.gameObject.tag == "Enemy")
            {
                spriteRenderer.color = Color.red;
            }
            else
            {
                detectedEnemy = null;
                spriteRenderer.color = Color.white;
            }
        }
        else
        {
            detectedEnemy = null;
            spriteRenderer.color = Color.white;
        }
    }
}
