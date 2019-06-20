using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InterfaceSegregation
{
    public interface IStats : IHealth
    {
        int STR { get; }
        int DEX { get; }

    }
}