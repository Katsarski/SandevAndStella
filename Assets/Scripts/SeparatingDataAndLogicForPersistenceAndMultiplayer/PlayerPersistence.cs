using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DataPersistence
{
    internal static class PlayerPersistance
    {
        internal static PlayerData GetData()
        {
            if (PlayerPrefs.HasKey("Health") == false)
            {
                return GetNewPlayerData();
            }
            return LoadFromPlayerPrefs();
        }

        public static PlayerData GetNewPlayerData()
        {
            return new PlayerData()
            {
                Health = 100,
                Mana = 100
            };
        }

        private static PlayerData LoadFromPlayerPrefs()
        {
            int health = PlayerPrefs.GetInt("Health");
            int mana = PlayerPrefs.GetInt("Mana");
            int movementSpeed = PlayerPrefs.GetInt("MovementSpeed");

            return new PlayerData()
            {
                Health = health,
                Mana = mana,
                MovementSpeed = movementSpeed
            };
        }

        internal static void SaveData(PlayerData playerData)
        {
            PlayerPrefs.SetInt("Health", playerData.Health);
            PlayerPrefs.SetInt("Mana", playerData.Mana);
            PlayerPrefs.SetInt("MovementSpeed", playerData.MovementSpeed);
        }
    }
}
