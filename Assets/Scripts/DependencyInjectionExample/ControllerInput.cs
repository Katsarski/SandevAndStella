using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : IShipInput
{
    public void ReadInput()
    {
        Rotation = Input.GetAxis("Horizontal");
        Thrust = Input.GetAxis("Vertical");
    }

    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
}
