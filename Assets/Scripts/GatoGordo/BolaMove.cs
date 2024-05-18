using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Transporting;

public class BolaMove : NetworkBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float maxSpeed;
    bool floorDetected = false;
    bool isJump = false;
    public float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isJump = Input.GetButtonDown("Jump");

        if (isJump && floorDetected)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 0.5f))
        {
            floorDetected = true;
        }
        else
        {
            floorDetected = false;
        }
    }


    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }


        Vector3 moveDirection = (Camera.main.transform.forward * moverVertical + Camera.main.transform.right * moverHorizontal).normalized;
        rb.AddForce(moveDirection * speed);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.black);
    }

    [ObserversRpc]
    void JumpClientRpc()
    {
        if (isJump && floorDetected)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    [ServerRpc]
    void MoveServerRpc(float moverHorizontal, float moverVertical)
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        Vector3 moveDirection = (Camera.main.transform.forward * moverVertical + Camera.main.transform.right * moverHorizontal).normalized;
        rb.AddForce(moveDirection * speed);
    }
}