using UnityEngine;
using System.Collections;

public class BallMover : MonoBehaviour {

    private Transform cameraTf;
    private Vector3 cameraTfForward;

    Rigidbody rb;

    public float moveSpeed = 5;
    public float maxAngularVelocity = 15;

    // Use this for initialization
    void Start()
    {
        cameraTf = Camera.main.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        //Finds the forward direction of the camera in the global space regardless of rotation
        cameraTfForward = Vector3.Scale(cameraTf.forward, new Vector3(1, 0, 1)).normalized;

        //Finds the vector corresponding global forward movement based on camera
        Vector3 moveDirection = (verticalMove * cameraTfForward + horizontalMove * cameraTf.right).normalized;

        //Adds Torque
        rb.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * moveSpeed);
    }
}
