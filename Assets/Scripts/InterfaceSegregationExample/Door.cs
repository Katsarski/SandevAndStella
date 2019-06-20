using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InterfaceSegregation
{
    public class Door : IHealth
    {
        public float Health { get; set; }
        public int HealthMax { get; }

        public int MaxHealth { get; }

        public void ModifyHealth(int amount)
        {
            Health -= amount;
        }
    }
}