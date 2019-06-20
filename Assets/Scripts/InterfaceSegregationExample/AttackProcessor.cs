using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InterfaceSegregation
{
    public class AttackProcessor : MonoBehaviour
    {
        public void ProcessMelee(IStats attacker, IHealth target)
        {
            int amount = CalculateAttackAmount(attacker);
            ProcessAttack(target, amount);
        }

        public int CalculateAttackAmount(IStats attacker)
        {
            return attacker.STR * 2;
        }

        public void ProcessAttack(IHealth target, int amount)
        {
            target.ModifyHealth(amount);
        }
    }
}