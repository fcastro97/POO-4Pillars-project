using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    private Rigidbody _vehicleRb;
    [SerializeField]
    private float _vehicleSpeed;
    public float VehicleSpeed
    {
        get => _vehicleSpeed;
        set => _vehicleSpeed = value;
    }
    [SerializeField]
    private float _vehicleTorque;
    public float VehicleTorque
    {
        get => _vehicleTorque;
        set => _vehicleTorque = value;
    }

    private void Awake()
    {
        _vehicleRb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {



        Movement();


    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _vehicleRb.AddRelativeForce(Vector3.forward * verticalInput * _vehicleSpeed * Time.deltaTime, ForceMode.Force);


        _vehicleRb.AddTorque(Vector3.up * horizontalInput * _vehicleTorque * Time.deltaTime, ForceMode.Acceleration);
    }


}
