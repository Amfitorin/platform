using System;
using System.Collections.Generic;
using MyRI.Configs.Collectables;
using MyRI.Mechanics.Effects;

namespace MyRI.Mechanics.Controllers.Collect
{
    public interface ICollectablesController: IDisposable
    {
        Dictionary<CarPartCollectable, int> CarParts { get; }
        List<BuffData> GainedBuffs { get; }
        event Action CarPartGained;
    }
}
