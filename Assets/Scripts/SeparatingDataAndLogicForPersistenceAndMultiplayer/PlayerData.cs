using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DataPersistence
{
    public class PlayerData : MonoBehaviour
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int MovementSpeed { get; set; }
    }
}