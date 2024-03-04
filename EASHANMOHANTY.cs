using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EASHANMOHANTY : MonoBehaviour
{
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;
    public float JumpForce = 2.0f;
    private bool isJumping = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = ((transform.right * hor) + (transform.forward * ver)) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.World);

        if (ver != 0 || hor != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
