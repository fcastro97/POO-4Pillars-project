using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    //Vars

    private float _horizontal;
    private float _verticalInput;
    [SerializeField] private float _motorForce;


    private bool _isBreaking;


    [SerializeField]
    private List<WheelCollider> wheels;




    //End vars





    private void FixedUpdate()
    {


        GetInput();
        Movement();


    }

    private void GetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _isBreaking = Input.GetKey(KeyCode.Space);


    }

    private void Movement()
    {


        foreach (var wheel in wheels)
        {
            wheel.motorTorque = _verticalInput * _motorForce;
        }

        




    }


}
