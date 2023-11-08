
using System;

namespace MyRI.Mechanics.LoopCycle
{
    /// <summary>
    /// provider for update loop cycle
    /// </summary>
    public interface IUpdateProvider : IDisposable
    {
        /// <summary>
        /// register update listener for cycle
        /// </summary>
        void RegisterUpdateListener(IUpdateListener listener);
        
        /// <summary>
        /// remove listener registration
        /// </summary>
        void RemoveUpdateListener(IUpdateListener listener);
    }
}
