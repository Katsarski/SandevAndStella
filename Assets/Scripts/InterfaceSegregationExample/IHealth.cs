using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InterfaceSegregation
{
    public interface IHealth
    {
        float Health { get; set; }
        int MaxHealth { get; }
        void ModifyHealth(int amount);
    }
}