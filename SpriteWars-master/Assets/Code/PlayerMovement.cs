using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;

    public Rigidbody2D rigidbody;
    public VariableJoystick movementJoystick;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (movementJoystick.Horizontal != 0 || movementJoystick.Vertical != 0)
        {
            Debug.Log("Hor:" + movementJoystick.Horizontal);
            Debug.Log("Ver:" + movementJoystick.Vertical);
        }


        movement.x = movementJoystick.Horizontal;
        movement.y = movementJoystick.Vertical;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
