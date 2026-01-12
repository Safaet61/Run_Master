using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obostaclemovement : MonoBehaviour
{

    public Vector3 rotationSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime));
    }
}
