using System;
using Project.com.ab.toolverse.sharedkernel;
using UnityEngine;

namespace com.ab.toolverse.harvest
{
    public class HarvestMono : MonoBehaviour, IHarvest
    {
        public ScriptableObject HarvestSo;
        IHarvestDef _harvestDef;
        public IHarvestDef HarvestDef => _harvestDef;

        void OnValidate()
        {
            ValidateHarvestSo();
        }

        void ValidateHarvestSo()
        {
            if (HarvestSo != null)
                if (HarvestSo is IHarvestDef def)
                    _harvestDef = def;
                else
                    throw new NotSupportedException($"{nameof(HarvestMono)}::Can not convert scriptableObject " +
                                                    $"reference from {nameof(HarvestMono.HarvestSo)} " +
                                                    $"to type {nameof(IHarvestDef)}");
        }
    }
}