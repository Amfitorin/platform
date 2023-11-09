using System;
using System.Collections.Generic;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Controllers.Collect
{
    
    /// <summary>
    /// collectables controller 
    /// </summary>
    public interface ICollectablesController : IDisposable
    {
        /// <summary>
        /// event invoked when character collect car part
        /// </summary>
        event Action CarPartGained;

        CarGun GunConfig { get; }

        Dictionary<CarPartCollectable, int> CarParts { get; }
    }
}
