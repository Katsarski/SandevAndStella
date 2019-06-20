using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPersistence
{
    public class Player : MonoBehaviour
    {
        private PlayerData playerData;
        // Start is called before the first frame update
        void Awake()
        {
            playerData = PlayerPersistance.GetData();
        }

        private void OnDestroy()
        {
            PlayerPersistance.SaveData(playerData);
        }
        void Update()
        {
            Debug.Log("Health: " + playerData.Health);
            if (Input.GetMouseButtonDown(0))
            {
                ModifyHealth(-1);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                playerData = PlayerPersistance.GetNewPlayerData();
            }

            
        }

        
        public void ModifyHealth(int amount)
        {
            playerData.Health += amount;
        }

    }
}