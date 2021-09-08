using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    //Vars

    private float _horizontalInput;
    private float _verticalInput;
    [SerializeField] private float _motorSpeed;
    [SerializeField] private float _brakeForce;
    [SerializeField] private float _maxSteeringAngle;
    public float MotorSpeed { get => _motorSpeed; set => _motorSpeed = value; }
    public float BrakeForce { get => _brakeForce; set => _brakeForce = value; }
    public float MaxSteeringAngle { get => _maxSteeringAngle; set => _maxSteeringAngle = value; }
    public WheelCollider FrontLeftWheel { get => _frontLeftWheel; set => _frontLeftWheel = value; }
    public WheelCollider FrontRightWheel { get => _frontRightWheel; set => _frontRightWheel = value; }
    public float CurrentBrakeForce { get => _currentBrakeForce; set => _currentBrakeForce = value; }
    public float HorizontalInput { get => _horizontalInput; set => _horizontalInput = value; }
    public float VerticalInput { get => _verticalInput; set => _verticalInput = value; }

    private float _steeringAngle;
    private float _currentBrakeForce;
    private bool _isBreaking;


    [SerializeField]
    private WheelCollider _frontLeftWheel;
    [SerializeField]
    private WheelCollider _frontRightWheel;
    [SerializeField]
    private WheelCollider _backLeftWheel;
    [SerializeField]
    private WheelCollider _backRightWheel;





    //End vars





    private void FixedUpdate()
    {


        GetInput();
        HandleMotor();
        HandleSteering();

    }



    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _isBreaking = Input.GetKey(KeyCode.Space);
        if (_isBreaking)
        {
            _currentBrakeForce = _brakeForce;
        }
        else
        {
            _currentBrakeForce = 0;
        }

        ApplyBrake();

    }

    public virtual void ApplyBrake()
    {
        _frontLeftWheel.brakeTorque = _currentBrakeForce;
        _frontRightWheel.brakeTorque = _currentBrakeForce;
        _backLeftWheel.brakeTorque = _currentBrakeForce;
        _backRightWheel.brakeTorque = _currentBrakeForce;

    }

    public virtual void HandleMotor()
    {


        _frontLeftWheel.motorTorque = _verticalInput * _motorSpeed * Time.deltaTime;
        _frontRightWheel.motorTorque = _verticalInput * _motorSpeed * Time.deltaTime;
        _backLeftWheel.motorTorque = _verticalInput * _motorSpeed * Time.deltaTime;
        _backRightWheel.motorTorque = _verticalInput * _motorSpeed * Time.deltaTime;

    }

    private void HandleSteering()
    {

        _steeringAngle = _maxSteeringAngle * _horizontalInput;
        _frontLeftWheel.steerAngle = _steeringAngle;
        _frontRightWheel.steerAngle = _steeringAngle;

    }
}
