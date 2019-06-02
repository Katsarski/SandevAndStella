using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotor
{
    private readonly IShipInput shipInput;
    private readonly Transform transformToMove;
    private readonly ShipSettings shipSettings;

    public ShipMotor(IShipInput shipInput, Transform transformToMove, ShipSettings shipSettings)
    {
        this.shipInput = shipInput;
        this.transformToMove = transformToMove;
        this.shipSettings = shipSettings;
    }

    public void Tick()
    {
        transformToMove.Rotate(Vector2.up * shipInput.Rotation * Time.deltaTime * shipSettings.TurnSpeed);
        transformToMove.position += transformToMove.forward * shipInput.Thrust * Time.deltaTime * shipSettings.MoveSpeed;
    }
}
