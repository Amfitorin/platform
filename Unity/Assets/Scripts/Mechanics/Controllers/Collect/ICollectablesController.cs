using System;

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
    }
}
