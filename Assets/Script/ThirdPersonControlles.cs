using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControlles : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity;


    public Transform groundSensor;
    public LayerMask ground;
    public float sensorRadius = 0.1f;

    public float speed = 5; 
    public float jumpForce = 20;
    private float gravity = -12f;
    public bool isGrounded; 
// -9.81f
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        controller.Move(move * speed * Time.deltaTime);

       // isGrounded = controller.isGrounded;
        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);
        if(isGrounded && playerVelocity.y < 0)
      {
        playerVelocity.y = 0;
      }

    if(Input.GetButtonDown("Jump") && isGrounded)
    {

    playerVelocity.y += jumpForce;

    }
    playerVelocity.y += gravity * Time.deltaTime;
    controller.Move(playerVelocity* Time.deltaTime);
    }
}
