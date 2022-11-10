using System;
using _ROOT.Scripts.Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _ROOT.Scripts.Fight
{
    public class UnitModificator
    {
        public float restoreChance;
        
        public float allAvailableChance;

        public void Init(EnemyStats settings)
        {
            restoreChance = settings.restoreChance;
            allAvailableChance = settings.allAvailableChance;
        }

        public void ModifyUnit(Unit unit)
        {
            if (Random.value < restoreChance)
            {
                unit.MakeRestore();
            }
            else if (Random.value < allAvailableChance)
            {
                unit.MakeAllAvailable();
            }
        }
    }
}