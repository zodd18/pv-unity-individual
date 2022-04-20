using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthIndicator : MonoBehaviour
{
    private Player player;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Round(player.health).ToString() + "";

        if (player.health <= (player.maxHealth * 0.25))
        {
            text.color = new Color(255,0,0);
        } 
        else if (player.health <= (player.maxHealth * 0.5))
        {
            text.color = new Color(255,100,0);
        } 
        else 
        {
            text.color = new Color(0, 255, 0);
        }
    }
}
