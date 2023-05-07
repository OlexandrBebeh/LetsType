namespace _ROOT.Scripts.Fight
{
    using System;
    using Settings;
    using UnityEngine;
    using Random = UnityEngine.Random;
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