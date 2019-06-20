using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount * 5);
    }
}
