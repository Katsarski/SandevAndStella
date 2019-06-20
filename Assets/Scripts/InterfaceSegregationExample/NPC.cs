using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceSegregation
{
    public class NPC : IStats
    {
        public int STR { get; }
        public int DEX { get; }

        public float Health { get; set; }

        public int MaxHealth { get; }

        public void ModifyHealth(int amount)
        {
            Health -= amount;
        }
    }
}