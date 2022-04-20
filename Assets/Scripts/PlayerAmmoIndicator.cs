using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmoIndicator : MonoBehaviour
{
    private Gun gun;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindWithTag("Player").GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gun.ammo.ToString() + "";

        if (gun.ammo <= (gun.maxAmmo * 0.1))
        {
            text.color = new Color(255,0,0);
        } 
        else if (gun.ammo <= (gun.maxAmmo * 0.2))
        {
            text.color = new Color(255,100,0);
        } 
        else 
        {
            text.color = new Color(255, 255, 255);
        }
    }
}
