using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : IShipInput
{
    public void ReadInput()
    {
        Rotation = Random.Range(-1f, 1f);
        Thrust = Random.Range(0f, 1f);
    }

    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
}
