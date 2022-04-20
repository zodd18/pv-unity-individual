using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 velocity;
    public float gravity = -9.81f;
    public CharacterController controller;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity.y += (gravity * 2) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = 0;
        }
    }
}
