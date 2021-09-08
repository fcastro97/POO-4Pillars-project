using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigVehicle : Vehicle
{

    [SerializeField]
    private List<WheelCollider> _backWheels;



    public override void ApplyBrake()
    {
        FrontLeftWheel.brakeTorque = CurrentBrakeForce;
        FrontRightWheel.brakeTorque = CurrentBrakeForce;

        foreach (WheelCollider backWheel in _backWheels)
        {
            backWheel.brakeTorque = CurrentBrakeForce;

        }


    }

    public override void HandleMotor()
    {


        FrontLeftWheel.motorTorque = VerticalInput * MotorSpeed * Time.deltaTime;
        FrontRightWheel.motorTorque = VerticalInput * MotorSpeed * Time.deltaTime;
        foreach (WheelCollider backWheel in _backWheels)
        {
            backWheel.motorTorque = VerticalInput * MotorSpeed * Time.deltaTime;

        }

    }



}
