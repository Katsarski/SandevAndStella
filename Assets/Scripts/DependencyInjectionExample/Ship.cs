using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipSettings shipSettings;

    private IShipInput shipInput;
    private ShipMotor shipMotor;

    // Start is called before the first frame update
    void Awake()
    {
        shipInput = shipSettings.UseAi ? new AiInput() as IShipInput : new ControllerInput();
        shipMotor = new ShipMotor(shipInput, transform, shipSettings);
    }

    // Update is called once per frame
    void Update()
    {
        shipInput.ReadInput();
        shipMotor.Tick();
    }
}
