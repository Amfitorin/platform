using System;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Notifier for buff attaching
    /// </summary>
    public interface IBuffNotify
    {
        /// <summary>
        /// Event invoked when character collect buff item
        /// </summary>
        event Action<BuffData> BuffGained;
    }
}
