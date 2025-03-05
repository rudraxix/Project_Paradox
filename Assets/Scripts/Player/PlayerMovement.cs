using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;
    public float Gravity = -10.0f;
    public float Jump_Height = 2f;

    private CharacterController controller;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right*moveX + transform.forward*moveZ;

        controller.Move(move * Speed * Time.deltaTime);

        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(Jump_Height * -2f * Gravity);
        }
    }
}
